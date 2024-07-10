using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.AppTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Models.Config
{
    public class BusConfiguration:IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.Property(b => b.Id).IsRequired().HasMaxLength(8);
            builder.Property(b=>b.Name).IsRequired().HasMaxLength(30);
            builder.Property(b => b.BusNumber).IsRequired();
            builder.Property(b => b.Capacity).HasMaxLength(2);
            builder.Property(b => b.BusType).IsRequired();
        }
        
    }
}