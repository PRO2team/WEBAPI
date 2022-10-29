using Webapi.Contexts;
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
