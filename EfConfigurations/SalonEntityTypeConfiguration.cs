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
            builder.Navigation(e => e.Address).AutoInclude();

            builder.HasMany(e => e.AppointmentTypes);
            builder.Navigation(e => e.AppointmentTypes).AutoInclude();

            builder.HasMany(e => e.OpenHours);
            builder.Navigation(e => e.OpenHours).AutoInclude();

            builder.HasMany(e => e.Pictures);
            builder.Navigation(e => e.Pictures).AutoInclude();
        }
    }
}