using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Shared.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(maximumLength:30, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
        public ICollection<ModuleDto> Modules { get; set; } = new List<ModuleDto>();

    }


}