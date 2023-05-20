using Microsoft.AspNetCore.Mvc;
using TrainingsAppApi.Dtos;
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

        
    }
}