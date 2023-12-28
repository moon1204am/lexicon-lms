namespace LexiconLMS.Shared.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Foreign Keys
        //public Guid UserId { get; set; }
        //public Guid ModuleId { get; set; }

        //Navigation Property
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();

    }


}