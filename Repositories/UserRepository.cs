using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using TrainingsAppApi.Entities;
using TrainingsAppApi.Models.Entities;
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
                          where email.ToLower() == currentEmail.Email.ToLower()
                          select currentEmail).Any();

            return result;
        }

        public UserEntity GetUser(string username)
        {
            var result = (from currentUsername in _appDbContext.Users
                          where username == currentUsername.Username
                          select currentUsername).FirstOrDefault<UserEntity>();

            if(result == null)
            {
                throw new ValidationException("Username does not exists");
            }
            return result;
        }

        public UserLoginEntity Login(string email, string password)
        {
            var user = _appDbContext.Users.Where(c => c.Email.ToLower() == email.ToLower() && c.Password == password).FirstOrDefault();

            if (user != null)
            {
                UserLoginEntity userLoginEntity = new UserLoginEntity(user.Username,user.IsTeacher);
                
                return userLoginEntity;
            }
            else
            {
                throw new ValidationException("Wrong Password");
            }
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
