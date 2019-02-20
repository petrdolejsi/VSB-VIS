namespace Library.Classes
{
    public class Logged
    {
        public static UserInfo CurrentUser { get; set; }
    }

    public class UserInfo
    {
        public int UserId { get; }

        public string UserRole { get; }

        public UserInfo(int userId, string userRole)
        {
            UserId = userId;
            UserRole = userRole;
        }
    }
}
