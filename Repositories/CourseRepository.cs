using MySqlX.XDevAPI.Common;
using NuGet.Protocol.Core.Types;
using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;
using TrainingsAppApi.Validation.Exceptions;

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

            var courses = (from course in _appDbContext.Courses
                           join user in _appDbContext.Users
                           on course.Id equals user.Id
                           where user.Username == username
                           select course).ToList<CourseEntity>();

            return courses;
        }

        public void SignToCourse(string courseName, string username)
        {
            var course = (from currentCourse in _appDbContext.Courses
                          where courseName == currentCourse.CourseName
                          select currentCourse).FirstOrDefault<CourseEntity>();

            var user = (from currentUser in _appDbContext.Users
                               where username == currentUser.Username
                          select currentUser).FirstOrDefault<UserEntity>();

            if (course != null && user != null)
            
                if(course.Users == null)
                {
                    UserEntity userEntity = user;
                    course.Users = new List<UserEntity> ();
                    course.Users.Add(userEntity);

                    CourseEntity courseEntity = course;
                    user.Courses = new List<CourseEntity>();
                    user.Courses.Add(courseEntity);

                    _appDbContext.Update(course.Users);
                    _appDbContext.Update(user.Courses);
                }
                else
                {
                    bool isUserAssigned = course.Users.Any(u => u.Username == username);

                    if (!isUserAssigned)
                    {
                        user.Courses.Add(course);
                        course.Users.Add(user);
                        _appDbContext.Update(course.Users);
                        _appDbContext.Update(user.Courses);
                    }
                }
                
            }
        }
}

