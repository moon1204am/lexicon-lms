using LexiconLMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconLMS.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
        [NotMapped]
        public string Role { get; set; }

        //Foreign Keys
        public Guid CourseId { get; set; }

        //Navigation Propery
        public Course Course { get; set; } = default!;
        //public ICollection<IdentityUserRole<string>> Roles { get; set; } = default!;
        //public ICollection<IdentityRole<string>> Role { get; set; }
    }
}
