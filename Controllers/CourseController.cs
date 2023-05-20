using Microsoft.AspNetCore.Mvc;
using TrainingsAppApi.Dtos;
using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Services;
using TrainingsAppApi.Validation.Exceptions;

namespace TrainingsAppApi.Controllers
{
    [ApiController]
    [Route("JDD")]
    public class CourseController : ControllerBase
    {


        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getcourses")]
        public IActionResult GetCourses()
        {

            _courseService.GetAllCourses();
            
            return Ok();
        }

        [HttpGet("getcourses")]
        public IActionResult SignToCourse(string username)
        {

            _courseService.SignToCourse(username);

            return Ok();
        }


    }
}