using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class SongAlbumConfiguration : IEntityTypeConfiguration<SongAlbum>
    {
        public void Configure(EntityTypeBuilder<SongAlbum> builder)
        {
            builder.HasKey(p => new { p.AlbumId, p.SongId });

            builder.HasOne(p => p.Album).WithMany(p => p.SongAlbums).HasForeignKey(p => p.AlbumId);
            builder.HasOne(p => p.Song).WithMany(p => p.SongAlbums).HasForeignKey(p => p.SongId);

            builder.Property(p => p.TrackNo).IsRequired();

            builder.HasCheckConstraint("constraint_trackno", $"{nameof(SongAlbum.TrackNo)} > 0");
        }
    }
}
