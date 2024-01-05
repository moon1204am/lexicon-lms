using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Shared.Dtos
{
    public class CreateUserDto
    {
        [Required, MaxLength(50), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50), MinLength(2)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        //public string FullName => $"{FirstName} {LastName}";

        public RoleDto RoleDto { get; set; }

        

        //Foreign Keys
        [Required]
        public Guid CourseId { get; set; }


    }
}
