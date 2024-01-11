using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Shared.Dtos
{
    public class ActivityAddDto
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now.AddDays(30);
        //public string TypeName { get; set; } = string.Empty;

        //Foreign Key
        [Required(ErrorMessage = "Selecting a module for the activity is required.")]
        public Guid ModuleId { get; set; }
        [Required(ErrorMessage = "Selecting a activity type for the activity is required.")]
        public Guid ActivityTypeId { get; set; }
    }
}