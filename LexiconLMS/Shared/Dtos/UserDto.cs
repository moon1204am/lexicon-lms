using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Shared.Dtos
{
    public class UserDto
    {
        public  Guid Id { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50), MinLength(2)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
        public string Role { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        public Guid CourseId { get; set; }
    }
}
