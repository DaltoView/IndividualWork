using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class SongArtistConfiguration : IEntityTypeConfiguration<SongArtist>
    {
        public void Configure(EntityTypeBuilder<SongArtist> builder)
        {
            builder.HasKey(p => new { p.ArtistId, p.SongId });

            builder.HasOne(p => p.Artist).WithMany(p => p.SongArtists).HasForeignKey(p => p.ArtistId);
            builder.HasOne(p => p.Song).WithMany(p => p.SongArtists).HasForeignKey(p => p.SongId);
        }
    }
}
