using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CountryId).IsRequired();
        }
    }
}
