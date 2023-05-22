using Microsoft.AspNetCore.Mvc;
using TrainingsAppApi.Dtos;
using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Services;
using TrainingsAppApi.Validation.Exceptions;

namespace TrainingsAppApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {


        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto dto)
        {

            try
            {
                _userService.RegisterUser(dto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto dto)
        {
            try
            {
                return Ok(_userService.LoginUser(dto));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}