
using TrainingsAppApi.Models.Entities;

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

        public List<CourseEntity> GetAllCourses(string username)
        {
            throw new NotImplementedException();
            //var result = (from currentCourse in _appDbContext.Courses
            //              where !currentCourse.User
            //              select currentCourse).ToList<CourseEntity>();
            //return result;
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
            throw new NotImplementedException();
            //var course = _appDbContext.Courses.FirstOrDefault(c => c.CourseName == courseName);

            
            //var user = _appDbContext.Users.FirstOrDefault(u => u.Username == username);

            //if (course != null && user != null)
            //{
            //    var isUserSigned = _appDbContext.Users.Any(a => a.Id == course.Id);

            //    if (!isUserSigned)
            //    {
                    
            //        course.Users.Add(user);
            //        _appDbContext.SaveChanges();
            //    }
            //}

        }
    }
}
