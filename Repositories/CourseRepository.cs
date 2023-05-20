
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

            throw new NotImplementedException();
            //List<CourseEntity> usersCourses = new List<CourseEntity>();


            //var result = (from currentCourse in _appDbContext.Courses
            //              where currentCourse.Users.Contains()
            //              select currentCourse).ToList<CourseEntity>();
            //return result;
        }

        public void SignToCourse(string courseName, string username)
        {
            throw new NotImplementedException();
            //var result = (from currentCourse in _appDbContext.Courses
            //              where courseName == currentCourse.CourseName
            //              select currentCourse).FirstOrDefault<CourseEntity>();
            
        }
    }
}
