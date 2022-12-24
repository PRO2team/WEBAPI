using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Webapi.Contexts;
namespace Webapi.Models
{
    public class Salon
    {
        public Salon()
        {
            AppointmentTypes = new List<AppointmentType>();
            Amentities = new List<Amentity>();
            OpenHours = new List<DayHours>();
            Reviews = new List<Review>();
        }

        public int SalonID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string? WebsiteURL { get; set; }
        public Address Address { get; set; }
        public virtual Picture? SalonPicture { get; set; }
        public virtual ICollection<AppointmentType> AppointmentTypes { get; set; }
        public virtual ICollection<Amentity> Amentities { get; set; }
        public virtual ICollection<DayHours> OpenHours { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
