using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(e => e.AppointmentID);
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.IsConfirmed).IsRequired();
            builder.Property(e => e.CalendarAppointmentURL).IsRequired();

            builder.HasOne(e => e.AppointmentType);

            builder.HasData(new Appointment()
            {
                AppointmentID = 1,
                Date = DateTime.Today,
                IsConfirmed = true,
                CalendarAppointmentURL = "google.com",
                AppointmentType = new AppointmentType() { AppointmentTypeID = 1, LengthMinutes = 30, Name = "Haircut", Price = 60 },
                User = new User() { UserID = 1, Name = "Hlib", Surname = "Pivniev", Birthdate = DateTime.Today.AddYears(-20), UserCredentials = new UserCredentials() { UserCredentialsID = 1, Email = "gl.pvn@gmail.com", PasswordHashed = "test123"} }
            });
        }
    }
}