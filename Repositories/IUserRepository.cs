using TrainingsAppApi.Entities;

namespace TrainingsAppApi.Repositories
{
    public interface IUserRepository
    {
        void Register(UserEntity entity);
        void Login(string username, string password);
        bool UsernameExists(string username);
        bool EmailExists(string email);

        string GetUser(string username);
    }
}
