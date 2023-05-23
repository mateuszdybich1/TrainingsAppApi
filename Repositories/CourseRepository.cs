using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using NuGet.Protocol.Core.Types;
using System.Xml.Linq;
using System;
using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;
using TrainingsAppApi.Validation.Exceptions;
using System.Linq;
using System.Security.Claims;

namespace TrainingsAppApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddCourse(CourseEntity entity)
        {
            _appDbContext.Courses.Add(entity);
            _appDbContext.SaveChanges();
        }

        public bool CourseExists(string courseName)
        {
            var result = (from currentCourse in _appDbContext.Courses
                          where courseName == currentCourse.CourseName
                          select currentCourse).Any();

            return result;
        }

        public List<CourseEntity> GetAllCourses()
        {
            var result = _appDbContext.Courses.ToList();
            return result;
        }

        public List<CourseEntity> GetSignToCourses(string username)
        {
            var user = _appDbContext.Users.FirstOrDefault(c => c.Username == username);
            var courseEntity = _appDbContext.Courses.Where(e=>!e.Users.Contains(user)).ToList();

            if (courseEntity != null)
            {
               

                if (courseEntity != null && courseEntity.Count == 0)
                {
                    throw new ValidationException("There is no new courses to register");
                }
                return courseEntity;

            }
            
            else
            {
                throw new ValidationException("UNEXPECTED ERROR");
            }
        }

        public List<CourseEntity> GetUsersCourses(string username)
        {
         
           var courses = _appDbContext.Users.Where(c => c.Username == username).SelectMany(c=>c.Courses).ToList();


            if (courses != null)
            {

                if (courses != null && courses.Count == 0)
                {
                    throw new ValidationException("You do not have any courses");
                }
                return courses;
            }
            else
            {
                throw new ValidationException("UNEXPECTED ERROR");
            }
   
        }

        public void SignToCourse(UserSignToCourseEntity userSignToCourse)
        {


            var course = _appDbContext.Courses.Include(e=>e.Users).FirstOrDefault(c => c.CourseName == userSignToCourse.CourseName);
            var user = _appDbContext.Users.Include(e => e.Courses).FirstOrDefault(u => u.Username == userSignToCourse.Username);
            if (course!=null)
            {
                if (user.Courses.Contains(course))
                {
                    throw  new ValidationException("User already signed to course");
                }
                
                
                user.Courses.Add(course);

                _appDbContext.SaveChanges();
                
            }

         
        }
     }
}

