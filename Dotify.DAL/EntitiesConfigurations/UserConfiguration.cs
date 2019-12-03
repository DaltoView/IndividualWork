using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sex).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.PasswordHash).HasMaxLength(100).IsRequired();
        }
    }
}
