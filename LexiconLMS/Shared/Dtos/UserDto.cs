namespace LexiconLMS.Shared.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public List<string> Roles {
            get;
            set;
        } = new List<string>();

     
    }
}
