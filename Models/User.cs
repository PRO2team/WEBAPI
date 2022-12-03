<<<<<<< HEAD
﻿namespace Webapi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Picture> ProfilePictures { get; set; }
        public UserCredentials UserCredentials { get; set; }
    }
}
=======
﻿namespace Webapi.Models
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
>>>>>>> 885ce6c3f4ead2c34edf8f810e97aaa8db77b916
