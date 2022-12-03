<<<<<<< HEAD
﻿using Webapi.Helpers;

namespace Webapi.Models
{
    public class UserCredentials
    {
        public enum UserRoles : int
        {
            [StringValue(nameof(Admin))]
            Admin,
            [StringValue(nameof(User))]
            User
        }

        public int UserCredentialsID { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHashed { get; set; }
        public string UserRole { get; set; }
        public byte[] Salt { get; set; }
        public byte[] RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }
    }
}
=======
﻿namespace Webapi.Models
{
    public class UserCredentials
    {
        public int UserCredentialsID { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
    }
}
>>>>>>> 885ce6c3f4ead2c34edf8f810e97aaa8db77b916
