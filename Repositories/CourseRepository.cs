using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using NuGet.Protocol.Core.Types;
using System.Xml.Linq;
using System;
using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;
using TrainingsAppApi.Validation.Exceptions;
using System.Linq;

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

            var result = (from currentCourse in _appDbContext.Courses
                          select currentCourse).ToList<CourseEntity>();
            return result;
        }

        public List<CourseEntity> GetUsersCourses(string username)
        {
         
           var user = _appDbContext.Users.Where(c => c.Username == username).Select(c=>c.Courses).FirstOrDefault();


            if (user != null)
            {

                if (user != null && user.Count == 0)
                {
                    throw new ValidationException("User do not have courses");
                }
                return user;
            }
            else
            {
                throw new ValidationException("UNEXPECTED ERROR");
            }
   
        }

        public void SignToCourse(string courseName, string username)
        {


            var course = _appDbContext.Courses.Include(c => c.Users).FirstOrDefault(c => c.CourseName == courseName);
            

            var user = _appDbContext.Users.Include(c => c.Courses).FirstOrDefault(c=>c.Username == username);

            if (course!=null)
            {

                if (course.Users.Any())
                {
                    throw new ValidationException("User already signed to course");
                }
                course.Users.Add(user);
                _appDbContext.SaveChanges();
            }

         
        }
     }
}

