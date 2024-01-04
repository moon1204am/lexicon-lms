using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

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

        public string FullName => $"{FirstName} {LastName}";

        //Todo: Add a property for the role here, when the SQL is resolved.
        //[Required]
        //public string Role { get; set; } = string.Empty;

        //Maya's code snippet
        //public string FullName => $"{FirstName} {LastName}";
        //public List<RoleDto> Roles { get; set; }
        //public RoleDto Role { get; set; } = default!;
        public string Role { get; set; }
        //public ICollection<IdentityUserRole<string>> Roles { get; set; }

        //Foreign Keys
        [Required]
        public Guid CourseId { get; set; }

        ////Navigation Property
        //public CourseDto Course { get; set; }
    }
}
