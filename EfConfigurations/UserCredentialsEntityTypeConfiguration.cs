<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
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
            builder.Property(e => e.Login).IsRequired();
            builder.Property(e => e.PasswordHashed).IsRequired();
            builder.Property(e => e.UserRole).IsRequired();
            builder.Property(e => e.Salt).IsRequired();
            builder.Property(e => e.RefreshToken).IsRequired();
            builder.Property(e => e.RefreshTokenExpirationDate).IsRequired();
        }
    }
}
=======
﻿using Microsoft.EntityFrameworkCore;
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
>>>>>>> 885ce6c3f4ead2c34edf8f810e97aaa8db77b916
