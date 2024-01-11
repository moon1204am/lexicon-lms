using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.Dtos
{
    public class ActivityTypeAddDto
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Name { get; set; } = string.Empty;

        //Foregin key
        public Guid ActivityId { get; set; }
    }
}
