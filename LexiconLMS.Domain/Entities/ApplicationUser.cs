using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        //Foreign Keys
        public Guid CourseId { get; set; }

        //Navigation Propery
        public Course Course { get; set; } = new Course();
    }
}
