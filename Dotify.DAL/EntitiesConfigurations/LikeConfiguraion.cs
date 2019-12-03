using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class LikeConfiguraion : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(p => new { p.SongId, p.UserId });
            builder.Property(p => p.Score).IsRequired();
            builder.Property(p => p.Date).IsRequired().HasDefaultValue(DateTime.MinValue);
            builder.HasCheckConstraint("constraint_score", $"{nameof(Like.Score)} > 0 AND {nameof(Like.Score)} < 6");
        }
    }
}