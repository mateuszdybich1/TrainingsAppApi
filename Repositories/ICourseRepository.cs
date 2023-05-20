using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Repositories
{
    public interface ICourseRepository
    {
        List<CourseEntity> GetAllCourses();
        void SignToCourse(string courseName,string username);
        bool CourseExists(string courseName);
        void AddCourse(CourseEntity entity);

        
    }
}
