using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Shared.Dtos
{
    public class UserDto
    {
        [Required, MaxLength(50), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50), MinLength(2)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        //public string FullName => $"{FirstName} {LastName}";

        ////Foreign Keys
        //public Guid CourseId { get; set; }

        ////Navigation Propery
        //public CourseDto Course { get; set; }
    }
}
