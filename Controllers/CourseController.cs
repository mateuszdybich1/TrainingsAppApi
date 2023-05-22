using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("getcourses")]
        public IActionResult GetAllCourses()
        {
            List<CourseEntity> list = _courseService.GetAllCourses();
            
       
            return Ok(list);
        }


        [HttpPost("getuserscourses")]
        public IActionResult GetUsersCourses(UsernameDto dto)
        {
            
            try
            {
                return Ok(_courseService.GetUsersCourses(dto));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            
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