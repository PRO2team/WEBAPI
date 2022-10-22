using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class UserCredentialsEntityTypeConfiguration : IEntityTypeConfiguration<UserCredentials>
    {
        public void Configure(EntityTypeBuilder<UserCredentials> builder)
        {
            builder.HasKey(e => e.UserCredentialsID);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.PasswordHashed).IsRequired();
        }
    }
}
