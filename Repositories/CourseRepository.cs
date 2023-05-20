
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

        public List<CourseEntity> GetAllCourses()
        {

            List<CourseEntity> list = new List<CourseEntity>();

            foreach(var course in _appDbContext.Courses)
            {
                list.Add(course);
            }
            return list;
        }

        public void SignToCourse(string courseName, string username)
        {
            throw new NotImplementedException();
        }
    }
}
