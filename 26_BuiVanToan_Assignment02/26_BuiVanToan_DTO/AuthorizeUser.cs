using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_DTO
{
    public class AuthorizeUser : User
    {
        public AuthorizeUser(User user)
        {
            EmailAddress = user.EmailAddress;
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
        public AuthorizeUser()
        {
        }
        public string AuthorizeRole { get; set; }

    }
}
