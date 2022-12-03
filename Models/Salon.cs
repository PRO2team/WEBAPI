<<<<<<< HEAD
﻿using Webapi.Contexts;
namespace Webapi.Models
{
    public class Salon
    {
        public int SalonID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string WebsiteURL { get; set; }
        public Picture Picture { get; set; }
        public Address Address { get; set; }
        public List<AppointmentType> AppointmentTypes { get; set; }
        public List<DayHours> OpenHours { get; set; }
    }
}
=======
﻿using Webapi.Contexts;
namespace Webapi.Models
{
    public class Salon
    {
        public int SalonID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string WebsiteURL { get; set; }
        public Address Address { get; set; }
        public List<AppointmentType> AppointmentTypes { get; set; }
        public List<DayHours> OpenHours { get; set; }
    }
}
>>>>>>> 885ce6c3f4ead2c34edf8f810e97aaa8db77b916
