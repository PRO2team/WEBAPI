using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserID);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Surname).IsRequired();
            builder.Property(e => e.Birthdate);

            builder.HasOne(e => e.Selfie);
            builder.HasOne(e => e.UserCredentials);
        }
    }
}
