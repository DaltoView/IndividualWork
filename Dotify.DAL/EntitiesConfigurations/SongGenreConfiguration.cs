using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class SongGenreConfiguration : IEntityTypeConfiguration<SongGenre>
    {
        public void Configure(EntityTypeBuilder<SongGenre> builder)
        {
            builder.HasKey(p => new { p.GenreId, p.SongId });

            builder.HasOne(p => p.Genre).WithMany(p => p.SongGenres).HasForeignKey(p => p.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Song).WithMany(p => p.SongGenres).HasForeignKey(p => p.SongId);
        }
    }
}