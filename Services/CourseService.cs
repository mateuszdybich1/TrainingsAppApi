using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Models.Entities;
using TrainingsAppApi.Repositories;
using TrainingsAppApi.Validation;
using TrainingsAppApi.Validation.Exceptions;

namespace TrainingsAppApi.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        public CourseService(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }
        public List<CourseEntity> GetAllCourses()
        {
            List<CourseEntity> courses = _courseRepository.GetAllCourses();
            return courses;
        }

        public void AddCourse(CourseDto dto)
        {
            if(_courseRepository.CourseExists(dto.CourseName))
            {
                throw new ValidationException(String.Format("Course name already exists"));
            }

            CourseEntity course = new (dto.Image,dto.CourseName,dto.StartDate,dto.EndDate,dto.StartTime,dto.EndDate,dto.Language,dto.CourseLevel,dto.TrainerName,);
        }

        public void SignToCourse(string courseName, string username)
        {

            CourseValidation courseValidation = new CourseValidation(_courseRepository, _userRepository);
            courseValidation.CanSignToCourse(courseName,username);


            _courseRepository.SignToCourse(courseName, username);
        }
    }
}
