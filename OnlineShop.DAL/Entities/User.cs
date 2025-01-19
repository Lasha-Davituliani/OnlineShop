namespace OnlineShop.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserRole Role { get; set; }
        public int FailedLogginAttempts { get; set; }
        public int FailedPasswordRessetAttempts { get; set; }
        public DateTime? BlockTime { get; set; }
        public bool IsActive { get; set; } = true;
    }

    [Flags]
    public enum UserRole : byte 
    {
        Admin = 1,
        Operator = 2,
    }
}
