using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class SalonEntityTypeConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.HasKey(e => e.SalonID);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.OwnerPhoneNumber).IsRequired();
            builder.Property(e => e.WebsiteURL);

            builder.HasOne(e => e.Address);

            builder.HasMany(e => e.AppointmentTypes);
            builder.HasMany(e => e.OpenHours);

            builder.HasData(new Salon()
            {
                SalonID = 1,
                Name = "Barber",
                Description = "Cool barbershop",
                OwnerPhoneNumber = "793224203",
                WebsiteURL = "google.com",
                Address = new Address()
                {
                    AddressID = 2,
                    City = "Warsaw",
                    Street = "Marszalkowska",
                    PostalCode = "04-125",
                    HouseNumber = "15D",
                    FlatNumber = "25A",
                },
                AppointmentTypes = new List<AppointmentType>()
                {
                    new AppointmentType()
                    {
                        AppointmentTypeID = 3,
                        LengthMinutes = 11,
                        Name = "Quick haircut",
                        Price = 32
                    }
                },
                OpenHours = new List<DayHours>()
                {
                    new DayHours()
                    {
                        DayHoursID = 8,
                        DayName = "Monday",
                        OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                        CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                    },
                    new DayHours()
                    {
                        DayHoursID = 9,
                        DayName = "Tuesday",
                        OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                        CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                    },
                    new DayHours()
                    {
                        DayHoursID = 10,
                        DayName = "Wednesday",
                        OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                        CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                    },
                    new DayHours()
                    {
                        DayHoursID = 11,
                        DayName = "Thursday",
                        OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                        CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                    },
                    new DayHours()
                    {
                        DayHoursID = 12,
                        DayName = "Friday",
                        OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                        CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                    },
                    new DayHours()
                    {
                        DayHoursID = 13,
                        DayName = "Saturday",
                        OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                        CloseTime = DateTime.Parse("01/01/2001 05:00:00 PM")
                    },
                    new DayHours()
                    {
                        DayHoursID = 14,
                        DayName = "Sunday",
                        OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                        CloseTime = DateTime.Parse("01/01/2001 05:00:00 PM")
                    }
                }
            });
        }
    }
}