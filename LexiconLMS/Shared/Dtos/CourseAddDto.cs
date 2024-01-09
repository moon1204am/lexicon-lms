using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace LexiconLMS.Shared.Dtos
{
    public class CourseAddDto
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "The {0} need to be between {2} and {1} characters long.")]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);
        public DocumentDto DocumentDto { get; set; } = new DocumentDto();
        //public string FileName { get; set; }
        //public string FileType { get; set; }
        //public byte[] FileContent { get; set; }
        //public DateTime UploadDate { get; set; }
        //public string UserId { get; set; }
        //public IFormFile Files { get; set; }
    }
}
