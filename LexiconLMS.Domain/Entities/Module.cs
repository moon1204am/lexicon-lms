using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //ForeignKey
        public Guid CourseId { get; set; }
        public Guid ActivityId { get; set; }

        //Navigation Property
        public Course Course { get; set; } = new Course();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

    }
}