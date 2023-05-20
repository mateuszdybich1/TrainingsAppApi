using System.ComponentModel.DataAnnotations;

namespace TrainingsAppApi.Models.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}
