using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
        }
    }
}
