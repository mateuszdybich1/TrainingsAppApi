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


           
            List<UserEntity> list = new List<UserEntity>();
            CourseEntity course = new CourseEntity();
            course.Image= dto.Image;
            course.CourseName = dto.CourseName;
            course.StartDate = dto.StartDate;
            course.EndDate = dto.EndDate;
            course.StartTime = dto.StartTime;
            course.EndTime = dto.EndTime;
            course.Language = dto.Language;
            course.Location = dto.Location;
            course.CourseLevel = dto.CourseLevel;
            course.TrainerName = dto.TrainerName;
            course.CourseTeacher = teacher;
            course.Users = list;


            _courseRepository.AddCourse(course);
            

        }

        public void SignToCourse(string courseName, string username)
        {

            CourseValidation courseValidation = new CourseValidation(_courseRepository, _userRepository);
            courseValidation.CanSignToCourse(courseName,username);


            _courseRepository.SignToCourse(courseName, username);
        }

        public List<CourseEntity> GetUsersCourses(UsernameDto dto)
        {
            CourseValidation courseValidation = new CourseValidation (_courseRepository, _userRepository);
            courseValidation.CanGetCourses(dto.username);
            
            List<CourseEntity> courses = _courseRepository.GetUsersCourses(dto.username);
            return courses;
        }

        public List<CourseEntity> GetAllCourses()
        {
            
            List<CourseEntity> courses = _courseRepository.GetAllCourses();
            return courses;
        }
    }
}
