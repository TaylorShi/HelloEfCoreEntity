using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Practing.Domain.AggregatesModel.OrderAggregates;
using Tesla.Practing.Infrastructure.Contexts;

namespace Tesla.Practing.Infrastructure.EntityConfigurations
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(o => o.Id);
            builder.Ignore(b => b.DomainEvents);

            //builder.OwnsOne(o => o.Address, a =>
            //{
            //    a.Property(p => p.Street).HasColumnName("Street");
            //    a.Property(p => p.City).HasColumnName("City");
            //    a.Property(p => p.State).HasColumnName("State");
            //    a.Property(p => p.Country).HasColumnName("Country");
            //    a.Property(p => p.ZipCode).HasColumnName("ZipCode");
            //});

            builder.OwnsOne(o => o.OrderDetails, od =>
            {
                od.OwnsOne(d => d.BillingAddress, a =>
                {
                    a.Property(p => p.Street).HasColumnName("Billing_Street");
                    a.Property(p => p.City).HasColumnName("Billing_City");
                    a.Property(p => p.State).HasColumnName("Billing_State");
                    a.Property(p => p.Country).HasColumnName("Billing_Country");
                    a.Property(p => p.ZipCode).HasColumnName("Billing_ZipCode");
                });
                od.OwnsOne(d => d.ShippingAddress, a =>
                {
                    a.Property(p => p.Street).HasColumnName("Shipping_Street");
                    a.Property(p => p.City).HasColumnName("Shipping_City");
                    a.Property(p => p.State).HasColumnName("Shipping_State");
                    a.Property(p => p.Country).HasColumnName("Shipping_Country");
                    a.Property(p => p.ZipCode).HasColumnName("Shipping_ZipCode");
                });
            });
        }
    }
}
