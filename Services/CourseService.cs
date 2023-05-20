using TrainingsAppApi.Entities;
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
        

        public void AddCourse(CourseDto dto)
        {
            if(_courseRepository.CourseExists(dto.CourseName))
            {
                throw new ValidationException("Course name already exists");
            }
            List<UserEntity> list = new List<UserEntity> {  };


            string teacherName = _userRepository.GetUser(dto.CurrentUserUsername);
            CourseEntity course = new (dto.Image,dto.CourseName,
                dto.StartDate,dto.EndDate,dto.StartTime,dto.EndDate,dto.Language,dto.CourseLevel,dto.TrainerName, teacherName, list);

            _courseRepository.AddCourse(course);
        }

        public void SignToCourse(string courseName, string username)
        {

            CourseValidation courseValidation = new CourseValidation(_courseRepository, _userRepository);
            courseValidation.CanSignToCourse(courseName,username);


            _courseRepository.SignToCourse(courseName, username);
        }

        public List<CourseEntity> GetUsersCourses(string username)
        {
            if (!_userRepository.UsernameExists(username))
            {
                throw new ValidationException("Username does not exists");
            }

            List<CourseEntity> courses = _courseRepository.GetUsersCourses(username);
            return courses;
        }

        public List<CourseEntity> GetAllCourses()
        {
            List<CourseEntity> courses = _courseRepository.GetAllCourses();
            return courses;
        }
    }
}
