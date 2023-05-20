using System.ComponentModel.DataAnnotations;

namespace TrainingsAppApi.Models.Dtos
{
    public class CourseDto
    {
        public string Image {get; set;}


        [Required(ErrorMessage = "Please enter Course name")]
        public string CourseName { get; set;}


        [Required(ErrorMessage = "Please enter course start date")]
        public string StartDate { get; set;}


        [Required(ErrorMessage = "Please enter course end date")]
        public string EndDate { get; set;}



        [Required(ErrorMessage = "Please enter course start time")] 
        public string StartTime { get; set;}



        [Required(ErrorMessage = "Please enter course end time")]
        public string EndTime { get; set;}



        [Required(ErrorMessage = "Please enter course language")]
        public string Language { get; set;}



        [Required(ErrorMessage = "Please enter course location")]
        public string Location { get; set;}



        [Required(ErrorMessage = "Please enter course level")]
        public string CourseLevel { get; set;}



        [Required(ErrorMessage = "Please enter course trainer name")]
        public string TrainerName { get; set;}
    }
}
