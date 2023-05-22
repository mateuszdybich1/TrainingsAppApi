using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingsAppApi.Dtos
{
    public class UserRegisterDto
    {
        
        
        [Required(ErrorMessage = "Please enter Username")]
        [StringLength(maximumLength: 15, ErrorMessage = "Username too long")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(maximumLength: 15, ErrorMessage = "First Name too long")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(maximumLength: 15, ErrorMessage = "Last Name too long")]
        public string?  LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "True or false")]
        public string IsTeacher { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
    }
}
