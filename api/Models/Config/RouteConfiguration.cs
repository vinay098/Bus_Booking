using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.AppTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.Config
{
    public class RouteConfiguration:IEntityTypeConfiguration<BusRoute>
    {
        public void Configure(EntityTypeBuilder<BusRoute> builder)
        {
            builder.Property(r => r.Id).IsRequired().HasMaxLength(8);
            builder.Property(r => r.Source).IsRequired().HasMaxLength(20);
            builder.Property(r => r.Destination).IsRequired().HasMaxLength(20);
            builder.Property(r => r.distance).IsRequired();
            builder.Property(r => r.duration).IsRequired();
        }
    }
}