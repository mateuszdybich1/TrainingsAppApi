using System.ComponentModel.DataAnnotations;

namespace TrainingsAppApi.Models.Dtos
{
    public class SignToCourseDto
    {
        [Required(ErrorMessage = "Please enter password")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        public string CourseName { get; set; }

        
    }
}
