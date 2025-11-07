using DataAccess.Entities;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(k =>  k.Id);
            builder.Property(p => p.DeliveryType).IsRequired();
            builder.Property(p => p.PaymentOption).IsRequired();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.DeliveryDate).IsRequired();

            builder
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(f => f.CustomerId);

            builder
                .HasOne(c => c.City)
                .WithMany(o => o.Orders)
                .HasForeignKey(f => f.CityId);

            builder.
                Property(o => o.PaymentOption)
               .HasConversion<string>();

            builder
                .Property(o => o.DeliveryType)
                .HasConversion<string>();

            builder.ToTable("orders");
        }
    }
}
