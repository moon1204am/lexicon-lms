namespace LexiconLMS.Shared.Dtos
{
    public class UserDto
    {

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        //Foreign Keys
        public Guid CourseId { get; set; }

        //Navigation Propery
        public CourseDto Course { get; set; } = new CourseDto();
    }
}
