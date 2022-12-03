<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;
using Webapi.Models;

namespace Webapi.EfConfigurations
{
    public class PictureEntityTypeConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(e => e.PictureID);
            builder.Property(e => e.Bytes).IsRequired();
            builder.Property(e => e.Extension).IsRequired();
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
    public class PictureEntityTypeConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(e => e.PictureID);
            builder.Property(e => e.Filepath).IsRequired();
        }
    }
}
>>>>>>> 885ce6c3f4ead2c34edf8f810e97aaa8db77b916
