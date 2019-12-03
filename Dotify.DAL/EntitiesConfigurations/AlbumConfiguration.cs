using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasCheckConstraint("constraint_year", $"({nameof(Album.Year)} > 1900) AND ({nameof(Album.Year)} <= YEAR(getdate()))");
        }
    }
}
