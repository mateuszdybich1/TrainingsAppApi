using Microsoft.AspNetCore.Mvc;
using TrainingsAppApi.Dtos;
using TrainingsAppApi.Models.Dtos;
using TrainingsAppApi.Models.Entities;
using TrainingsAppApi.Services;
using TrainingsAppApi.Validation.Exceptions;

namespace TrainingsAppApi.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _courseService;


        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpPost("addcourse")]
        public IActionResult AddCourse(CourseDto course)
        {
            try
            {
                _courseService.AddCourse(course);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


       
        [HttpGet("getuserscourses")]
        public IActionResult GetUsersCourses(string username)
        {
            List<CourseEntity> list = _courseService.GetUsersCourses(username);
            try
            {
                list = _courseService.GetUsersCourses(username);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(list);
        }


        [HttpPost("signtocourse")]
        public IActionResult SignToCourse(string courseName, string username)
        {
            try
            {
                _courseService.SignToCourse(courseName, username);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }




    }
}