﻿using TrainingsAppApi.Dtos;
using TrainingsAppApi.Models.Dtos;

namespace TrainingsAppApi.Services
{
    public interface IUserService
    {
        void RegisterUser(UserRegisterDto dto);

        void LoginUser(UserLoginDto dto);
    }
}
