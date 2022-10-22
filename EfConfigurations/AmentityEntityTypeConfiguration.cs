using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class AmentityEntityTypeConfiguration : IEntityTypeConfiguration<Amentity>
    {
        public void Configure(EntityTypeBuilder<Amentity> builder)
        {
            builder.HasKey(e => e.AmentityID);
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Icon);

            builder.HasData(new Amentity()
            {
                AmentityID = 1,
                Name = "Parking",
                Icon = new Picture() { PictureID = 1, Filepath = "E:/Pictures/ParkingIcon.png"}
            });
        }
    }
}
