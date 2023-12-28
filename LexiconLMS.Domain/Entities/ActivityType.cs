using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Domain.Entities
{
    public class ActivityType
    {
        public Guid Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        //Navigation Property
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

    }
}