using TrainingsAppApi.Entities;

namespace TrainingsAppApi.Models.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; }

        public string Image { get;  set; }

        public string CourseName { get; set; }

        public string StartDate { get;  set; }

        public string EndDate { get;  set; }

        public string StartTime { get;  set; }

        public string EndTime { get;  set; }

        public string Language { get; set; }

        public string CourseLevel { get; set; }

        public string TrainerName { get; set; }

        public string CourseTeacher { get; private set; }

        

        public List<UserEntity> User { get; private set; }

        public CourseEntity(string? image , string courseName, string startDate, string endDate, string startTime, string endTime, string language, string courseLevel, string trainerName, string courseTeacher, List<UserEntity> user)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentException($"'{nameof(courseName)}' cannot be null or empty.", nameof(courseName));
            }

            if (string.IsNullOrEmpty(startDate))
            {
                throw new ArgumentException($"'{nameof(startDate)}' cannot be null or empty.", nameof(startDate));
            }

            if (string.IsNullOrEmpty(endDate))
            {
                throw new ArgumentException($"'{nameof(endDate)}' cannot be null or empty.", nameof(endDate));
            }

            if (string.IsNullOrEmpty(startTime))
            {
                throw new ArgumentException($"'{nameof(startTime)}' cannot be null or empty.", nameof(startTime));
            }

            if (string.IsNullOrEmpty(endTime))
            {
                throw new ArgumentException($"'{nameof(endTime)}' cannot be null or empty.", nameof(endTime));
            }

            if (string.IsNullOrWhiteSpace(language))
            {
                throw new ArgumentException($"'{nameof(language)}' cannot be null or whitespace.", nameof(language));
            }

            if (string.IsNullOrWhiteSpace(courseLevel))
            {
                throw new ArgumentException($"'{nameof(courseLevel)}' cannot be null or whitespace.", nameof(courseLevel));
            }

            if (string.IsNullOrEmpty(trainerName))
            {
                throw new ArgumentException($"'{nameof(trainerName)}' cannot be null or empty.", nameof(trainerName));
            }

            if (string.IsNullOrWhiteSpace(courseTeacher))
            {
                throw new ArgumentException($"'{nameof(courseTeacher)}' cannot be null or whitespace.", nameof(courseTeacher));
            }

            Image = image;
            CourseName = courseName;
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
            Language = language;
            CourseLevel = courseLevel;
            TrainerName = trainerName;
            User = user;
            CourseTeacher = courseTeacher;
        }
        public CourseEntity()
        {
            
        }
    }
}
