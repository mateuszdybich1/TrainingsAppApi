using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Repositories
{
    public interface IUserRepository
    {
        void Register(UserEntity entity);
        UserLoginEntity Login(string email, string password);
        bool UsernameExists(string username);
        bool EmailExists(string email);

        UserEntity GetUser(string username);
    }
}
