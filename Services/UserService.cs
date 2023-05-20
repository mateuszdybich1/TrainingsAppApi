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

        public void LoginUser(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserRegisterDto dto)
        {

            UserValidation userValidation = new UserValidation(_userRepository);
            userValidation.ValidateUsername(dto.Username);
            userValidation.ValidateEmail(dto.Email);

            List<CourseEntity> courses = new List<CourseEntity>();

            Guid guid = Guid.NewGuid();
            UserEntity user = new UserEntity(guid, dto.Username,dto.FirstName,dto.LastName,dto.Email,dto.Password,dto.IsTeacher,dto.Country,dto.City,dto.Street, courses);
            _userRepository.Register(user);
        }
    }
}
