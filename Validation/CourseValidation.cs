using TrainingsAppApi.Repositories;
using TrainingsAppApi.Validation.Exceptions;

namespace TrainingsAppApi.Validation
{
    public class CourseValidation
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        public CourseValidation(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public void CanAddCourse(string courseName, string username)
        {
            if (_courseRepository.CourseExists(courseName))
            {
                throw new ValidationException(String.Format("Course name already exists"));
            }
            if (!_userRepository.UsernameExists(username))
            {
                throw new ValidationException(String.Format("Username do not exists"));
            }
        }

        public void CanSignToCourse(string courseName, string username)
        {
            if (!_courseRepository.CourseExists(courseName))
            {
                throw new ValidationException(String.Format("Course name do not exists"));
            }
            if (!_userRepository.UsernameExists(username))
            {
                throw new ValidationException(String.Format("Username do not exists"));
            }
        }

        public void CanGetCourses( string username)
        {
            if (!_userRepository.UsernameExists(username))
            {
                throw new ValidationException(String.Format("Username do not exists"));
            }
           
        }
    }
}
