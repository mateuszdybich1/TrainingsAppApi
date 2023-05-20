using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using TrainingsAppApi.Entities;
using TrainingsAppApi.Validation.Exceptions;

namespace TrainingsAppApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool EmailExists(string email)
        {
            var result = (from currentEmail in _appDbContext.Users
                          where email == currentEmail.Email
                          select currentEmail).Any();

            return result;
        }

        public string GetUser(string username)
        {
            var result = (from currentUsername in _appDbContext.Users
                          where username == currentUsername.Username
                          select currentUsername.Username).SingleOrDefault<string>();

            if(result == null)
            {
                throw new ValidationException("Username does not exists");
            }
            return result;
        }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(UserEntity entity)
        {
           _appDbContext.Users.Add(entity);
            _appDbContext.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            var result = (from currentUsername in _appDbContext.Users
                          where username == currentUsername.Username
                          select currentUsername).Any();

            return result;
        }
    }
}
