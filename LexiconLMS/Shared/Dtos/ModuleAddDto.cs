using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Shared.Dtos
{
    public class ModuleAddDto
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);

        //Foreign Key
        [Required(ErrorMessage = "Selecting a course for the module is required.")]
        public Guid CourseId { get; set; }
    }
}
