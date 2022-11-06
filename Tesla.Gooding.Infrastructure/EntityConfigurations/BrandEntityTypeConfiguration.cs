using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Infrastructure.EntityConfigurations
{
    internal class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("brand");
            builder.HasKey(p => p.Id);
            // 忽略领域事件这个字段
            builder.Ignore(b => b.DomainEvents);
            builder.Property(p => p.Name).HasMaxLength(500);
            builder.Property(p => p.Code).HasMaxLength(300);
            builder.HasIndex(p => p.Code);
            builder.HasIndex(p => p.Name);
        }
    }
}
