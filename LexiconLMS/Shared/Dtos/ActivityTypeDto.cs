namespace LexiconLMS.Shared.Dtos
{
    public class ActivityTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Navigation Property
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

    }
}