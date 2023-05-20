using TrainingsAppApi.Repositories;
using TrainingsAppApi.Validation.Exceptions;

namespace TrainingsAppApi.Validation
{
    public class UserValidation
    {
        private readonly IUserRepository _userRepository;

        public UserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ValidateUsername(string username)
        {
            if (_userRepository.UsernameExists(username))
            {
                throw new ValidationException(String.Format("Username: {0} is taken.", username));
            }
        }

        public void ValidateEmail(string email)
        {
            if (_userRepository.EmailExists(email))
            {
                throw new ValidationException(String.Format("Email: {0} already exists. Please Log in.", email));
            }
        }
    }
}
