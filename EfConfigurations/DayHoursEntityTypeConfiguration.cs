using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class DayHoursEntityTypeConfiguration : IEntityTypeConfiguration<DayHours>
    {
        public void Configure(EntityTypeBuilder<DayHours> builder)
        {
            builder.HasKey(e => e.DayHoursID);
            builder.Property(e => e.DayName).IsRequired();
            builder.Property(e => e.OpenTime).IsRequired();
            builder.Property(e => e.CloseTime).IsRequired();

            builder.HasData(new DayHours[]
            {
                new DayHours()
                {
                    DayHoursID = 1,
                    DayName = "Monday",
                    OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                    CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                },
                new DayHours()
                {
                    DayHoursID = 2,
                    DayName = "Tuesday",
                    OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                    CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                },
                new DayHours()
                {
                    DayHoursID = 3,
                    DayName = "Wednesday",
                    OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                    CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                },
                new DayHours()
                {
                    DayHoursID = 4,
                    DayName = "Thursday",
                    OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                    CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                },
                new DayHours()
                {
                    DayHoursID = 5,
                    DayName = "Friday",
                    OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                    CloseTime = DateTime.Parse("01/01/2001 07:00:00 PM")
                },
                new DayHours()
                {
                    DayHoursID = 6,
                    DayName = "Saturday",
                    OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                    CloseTime = DateTime.Parse("01/01/2001 05:00:00 PM")
                },
                new DayHours()
                {
                    DayHoursID = 7,
                    DayName = "Sunday",
                    OpenTime = DateTime.Parse("01/01/2001 07:00:00 AM"),
                    CloseTime = DateTime.Parse("01/01/2001 05:00:00 PM")
                },
            });
        }
    }
}
