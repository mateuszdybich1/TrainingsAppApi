using TrainingsAppApi.Dtos;
using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Models.Entities;
using TrainingsAppApi.Repositories;
using TrainingsAppApi.Validation;

namespace TrainingsAppApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserLoginEntity LoginUser(UserLoginDto dto)
        {
            UserValidation userValidation = new UserValidation(_userRepository);
            userValidation.LoginEmail(dto.Email);

            return _userRepository.Login(dto.Email, dto.Password);
        }

        public void RegisterUser(UserRegisterDto dto)
        {

            UserValidation userValidation = new UserValidation(_userRepository);
            userValidation.ValidateUsername(dto.Username);
            userValidation.RegisterEmail(dto.Email);

            List<CourseEntity> courses = new List<CourseEntity>();

            Guid guid = Guid.NewGuid();
            UserEntity user = new UserEntity(guid, dto.Username,dto.FirstName,dto.LastName,dto.Email,dto.Password,dto.IsTeacher,dto.Country,dto.City,dto.Street, courses);
            _userRepository.Register(user);
        }
    }
}
