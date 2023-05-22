namespace TrainingsAppApi.Models.Entities
{
    public class UserLoginEntity
    {
        string Username { get; set; }
        string IsTeacher { get; set; }

        public UserLoginEntity(string username, string isTeacher)
        {
            Username = username;
            IsTeacher = isTeacher;
        }
    }
}
