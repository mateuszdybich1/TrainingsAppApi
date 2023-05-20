using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Services
{
    public interface ICourseService
    {
        List<CourseEntity> GetAllCourses();

        List<CourseEntity> GetUsersCourses(string username);
        void SignToCourse(string courseName,string username);

        void AddCourse(CourseDto dto);
    }
}
