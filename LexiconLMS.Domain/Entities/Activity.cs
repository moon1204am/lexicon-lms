using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Domain.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        //Foreign key

        public Guid ModuleId { get; set; }

        public Guid ActivityTypeId { get; set; }

        //Navigation Properties

        public Module Module { get; set; } = new Module();

        public ActivityType Type { get; set; } = new ActivityType();


    }
}