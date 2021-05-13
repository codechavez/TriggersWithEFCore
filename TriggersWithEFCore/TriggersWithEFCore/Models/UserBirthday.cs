namespace TriggersWithEFCore.Models
{
    public class UserBirthday
    {
        public long UserBirthdayId { get; set; }
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
    }
}
