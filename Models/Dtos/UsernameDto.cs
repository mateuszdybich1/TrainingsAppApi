using System.ComponentModel.DataAnnotations;

namespace TrainingsAppApi.Models.Dtos
{
    public class UsernameDto
    {
        [Required(ErrorMessage = "Please enter Username")]
        public string username { get; set; }
    }
}
