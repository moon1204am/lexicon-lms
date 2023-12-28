using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        //Foreign Keys
        public Guid CourseId { get; set; }

        //Navigation Propery
        public Course Course { get; set; } = default!;
    }
}
