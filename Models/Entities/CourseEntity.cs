using TrainingsAppApi.Entities;

namespace TrainingsAppApi.Models.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; private set; }

        public string Image { get;  set; }

        public string CourseName { get;  set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Language { get; set; }

        public string Location { get; set; }

        public string CourseLevel { get; set; }

        public string TrainerName { get; set; }

        public string CourseTeacher { get; set; }

        public List<UserEntity> Users { get; set; }

       
        public CourseEntity()
        {
            
        }
    }
}
