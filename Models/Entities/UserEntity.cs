using System.ComponentModel.DataAnnotations;
using TrainingsAppApi.Models.Entities;

namespace TrainingsAppApi.Entities
{
    public class UserEntity { 

    public Guid Id { get; private set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string IsTeacher { get; set; }

    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public List<CourseEntity> Courses { get; set; }


    public UserEntity(Guid id, string username, string firstname,
            string lastname, string email, string password,
            string isteacher, string country, string city, string street, List<CourseEntity> courses )
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentException($"'{nameof(firstname)}' cannot be null or whitespace.", nameof(firstname));
            }

            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentException($"'{nameof(lastname)}' cannot be null or whitespace.", nameof(lastname));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
            }

            

            Username = username;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            IsTeacher = isteacher;
            Country = country;
            City = city;
            Street = street;
            Courses = courses;
            Id = id;
        }

        public UserEntity()
        {
            
        }
    }
}
