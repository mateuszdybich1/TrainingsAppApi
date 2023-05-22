using TrainingsAppApi.Dtos;
using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Services
{
    public interface IUserService
    {
        void RegisterUser(UserRegisterDto dto);

        UserLoginEntity LoginUser(UserLoginDto dto);
    }
}
