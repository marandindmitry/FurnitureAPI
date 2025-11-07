using DataAccess.Entities;
using Domain.Abstractions;
using Domain.Models;
using Domain.Models.FurnitureModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities.FurnitureEntities;

namespace DataAccess.EntityConfigurations
{
    public class FurnitureConfiguration : IEntityTypeConfiguration<FurnitureEntity>
    {
        public void Configure(EntityTypeBuilder<FurnitureEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Producer).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Material).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Color).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Width).HasColumnType("DOUBLE(7, 2)").IsRequired();
            builder.Property(p => p.Height).HasColumnType("DOUBLE").HasPrecision(7, 2).IsRequired();
            builder.Property(p => p.Price).HasColumnType("FLOAT(10, 2)").IsRequired();

            builder.Property(p => p.IsInBasket).IsRequired();

            builder
                .HasOne(o => o.Order)
                .WithMany(f => f.Furniture)
                .HasForeignKey(f => f.OrderId);

            builder
                .HasDiscriminator<string>("Discriminator")
                .HasValue<TableEntity>("Table")
                .HasValue<ChairEntity>("Chair");

            builder.ToTable("furniture");
        }
    }
}
