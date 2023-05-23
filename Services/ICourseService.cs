using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Services
{
    public interface ICourseService
    {
        List<CourseEntity> GetAllCourses();
        List<CourseEntity> GetSignToCourses(UsernameDto dto);

        List<CourseEntity> GetUsersCourses(UsernameDto dto);
        void SignToCourse(SignToCourseDto dto);

        void AddCourse(CourseDto dto);
    }
}
