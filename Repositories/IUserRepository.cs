using TrainingsAppApi.Entities;

namespace TrainingsAppApi.Repositories
{
    public interface IUserRepository
    {
        void Register(UserEntity entity);
        string Login(string email, string password);
        bool UsernameExists(string username);
        bool EmailExists(string email);

        UserEntity GetUser(string username);
    }
}
