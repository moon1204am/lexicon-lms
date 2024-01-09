using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.Dtos
{
    public class UpdateUserDto
    {
        [Required, MaxLength(50), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50), MinLength(2)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Optional: Include RoleId if you want to allow updating the Role ; requires additional logic in the controller
        // [Required]
        // public Guid RoleId { get; set; }
    }
}
