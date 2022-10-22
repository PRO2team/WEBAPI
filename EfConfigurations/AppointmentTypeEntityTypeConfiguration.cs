using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class AppointmentTypeEntityTypeConfiguration : IEntityTypeConfiguration<AppointmentType>
    {
        public void Configure(EntityTypeBuilder<AppointmentType> builder)
        {
            builder.HasKey(e => e.AppointmentTypeID);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.LengthMinutes).IsRequired();
            builder.Property(e => e.Price).IsRequired();

            builder.HasMany(e => e.Pictures);

            builder.HasData(new AppointmentType()
            {
                AppointmentTypeID = 2,
                LengthMinutes = 10,
                Name = "Quick haircut",
                Price = 30
            });
        }
    }
}