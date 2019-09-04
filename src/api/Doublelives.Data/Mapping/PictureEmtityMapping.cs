using Doublelives.Domain.Pictures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Data.Mapping
{
    public class PictureEmtityMapping : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");
            builder.HasKey(c => c.Id);

            builder.HasIndex(it => it.Url);
            builder.HasIndex(it => it.Uploader);
            builder.HasIndex(it => it.Size);
        }
    }
}
