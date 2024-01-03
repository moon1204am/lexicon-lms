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

        //Todo: Add a property for the role here, when the SQL is resolved.
        //[Required]
        //public string Role { get; set; } = string.Empty;


        //Foreign Keys
        [Required]
        public Guid CourseId { get; set; }

        ////Navigation Property
        //public CourseDto Course { get; set; }
    }
}
