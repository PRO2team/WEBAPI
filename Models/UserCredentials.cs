namespace Webapi.Models
{
    public class UserCredentials
    {
        public int UserCredentialsID { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
    }
}
