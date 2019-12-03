using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EntitiesConfigurations
{
    class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(p => p.CountryId).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
