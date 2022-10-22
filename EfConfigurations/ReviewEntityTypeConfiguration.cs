using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(e => e.ReviewID);

            builder.Property(e => e.Rating).IsRequired();
            builder.Property(e => e.Comment).IsRequired();
            builder.Property(e => e.PostedTimestamp).IsRequired();

            builder.HasOne(e => e.Appointment);

            builder.HasData(new Review()
            {
                ReviewID = 1,
                Rating = 5,
                Comment = "Very cool",
                PostedTimestamp = DateTime.Now,
                Appointment = new Appointment() { AppointmentID = 2, CalendarAppointmentURL = "google.com", Date = DateTime.Now, IsConfirmed = true, AppointmentType = new AppointmentType() { AppointmentTypeID = 3, LengthMinutes = 33, Name = "Haircut", Price = 55 }, User = new User() { UserID = 2, Name = "Hlib", Surname = "Pivniev2", Birthdate = DateTime.Today.AddYears(-20), Selfie = new Picture() { Filepath = "E:/Pictures/defaultAvatar.png" }, UserCredentials = new UserCredentials() { UserCredentialsID = 1, Email = "gl.pvn2@gmail.com", PasswordHashed = "test123" } } }
            });
        }
    }
}