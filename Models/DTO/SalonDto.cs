namespace Webapi.Models.DTO
{
    public class SalonDto
    {
        public SalonDto(Salon salon)
        {
            SalonID = salon.SalonID;
            Name = salon.Name;
            Description = salon.Description;
            OwnerPhoneNumber = salon.OwnerPhoneNumber;
            WebsiteURL = salon.WebsiteURL;
            SalonType = salon.SalonType;
            AverageRating = salon.Reviews.Any() ? salon.Reviews.Select(e => e.Rating).Average() : null;
            AverageCheck = salon.AppointmentTypes.Any() ? salon.AppointmentTypes.Select(e => e.Price).Average() : null;
            Address = salon.Address;
            SalonPicture = salon.SalonPicture;
            AppointmentTypes = salon.AppointmentTypes;
            Amentities = salon.Amentities;
            OpenHours = salon.OpenHours;
            Reviews = salon.Reviews;
        }

        public int SalonID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string? WebsiteURL { get; set; }
        public string SalonType { get; set; }
        public double? AverageRating { get; set; }
        public decimal? AverageCheck { get; set; }
        public Address Address { get; set; }
        public virtual Picture? SalonPicture { get; set; }
        public virtual ICollection<AppointmentType> AppointmentTypes { get; set; }
        public virtual ICollection<Amentity> Amentities { get; set; }
        public virtual ICollection<DayHours> OpenHours { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
