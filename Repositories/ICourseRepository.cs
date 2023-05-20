using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Repositories
{
    public interface ICourseRepository
    {
        List<CourseEntity> GetAllCourses(string username);
        List<CourseEntity> GetUsersCourses(string username);
        void SignToCourse(string courseName,string username);
        bool CourseExists(string courseName);
        void AddCourse(CourseEntity entity);

        
    }
}
