namespace LexiconLMS.Shared.Dtos
{
    public class ActivityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TypeName { get; set; } = string.Empty;
        //public Guid TypeId { get; set; }
        //public ActivityTypeDto Type { get; set; }
        public Guid ActivityTypeId { get; set; }
        //public Guid ModuleId { get; set; }
    }
}