namespace Webapi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Picture Selfie { get; set; }
        public UserCredentials UserCredentials { get; set; }
    }
}
