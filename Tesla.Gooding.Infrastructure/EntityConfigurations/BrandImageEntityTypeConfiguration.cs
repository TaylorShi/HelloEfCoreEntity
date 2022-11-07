using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Infrastructure.EntityConfigurations
{
    internal class BrandImageEntityTypeConfiguration : IEntityTypeConfiguration<BrandImage>
    {
        public void Configure(EntityTypeBuilder<BrandImage> builder)
        {
            builder.ToTable("brandimage");
            builder.HasKey(p => p.Id);
            // 忽略领域事件这个字段
            builder.Ignore(b => b.DomainEvents);
            builder.Property(p => p.Url).HasMaxLength(500);
            builder.Property(p => p.Code).HasMaxLength(300);
            builder.Property(p => p.Type).HasDefaultValue(BrandImageType.UnKnown);
            builder.HasIndex(p => p.Code);
            builder.HasIndex(p => p.Type);
        }
    }
}
