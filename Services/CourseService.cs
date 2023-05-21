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
            CourseValidation validation = new  CourseValidation(_courseRepository,_userRepository);
            validation.CanAddCourse(dto.CourseName, dto.CurrentUserUsername);

            string teacher = dto.CurrentUserUsername;
            if(!_userRepository.UsernameExists(teacher))
            {
                throw new ValidationException("Invalid username");
            }

            List<UserEntity> list = new List<UserEntity>
            {
                _userRepository.GetUser(teacher)
            };

            CourseEntity course = new CourseEntity();
            course.Image= dto.Image;
            course.CourseName = dto.CourseName;
            course.StartDate = dto.StartDate;
            course.EndDate = dto.EndDate;
            course.StartTime = dto.StartTime;
            course.EndTime = dto.EndTime;
            course.Language = dto.Language;
            course.CourseLevel = dto.CourseLevel;
            course.TrainerName = dto.TrainerName;
            course.CourseTeacher = teacher;
            course.Users = list;
            _courseRepository.AddCourse(course);
            //CourseEntity course = new (dto.Image,dto.CourseName,dto.StartDate,dto.EndDate,dto.StartTime,dto.EndDate,dto.Language,dto.CourseLevel,dto.TrainerName,teacher ,list);


        }

        public void SignToCourse(string courseName, string username)
        {

            CourseValidation courseValidation = new CourseValidation(_courseRepository, _userRepository);
            courseValidation.CanSignToCourse(courseName,username);


            _courseRepository.SignToCourse(courseName, username);
        }

        public List<CourseEntity> GetUsersCourses(string username)
        {
            CourseValidation courseValidation = new CourseValidation (_courseRepository, _userRepository);
            courseValidation.CanGetCourses(username);
            
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
