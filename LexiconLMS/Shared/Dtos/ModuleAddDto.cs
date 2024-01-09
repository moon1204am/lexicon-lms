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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Foreign Key
        public Guid CourseId { get; set; }
    }
}
