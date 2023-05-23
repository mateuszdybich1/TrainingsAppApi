using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Repositories
{
    public interface ICourseRepository
    {
        List<CourseEntity> GetAllCourses();
        List<CourseEntity> GetSignToCourses(string username);
        List<CourseEntity> GetUsersCourses(string username);
        void SignToCourse(UserSignToCourseEntity userSignToCourse);
        bool CourseExists(string courseName);
        void AddCourse(CourseEntity entity);

        
    }
}
