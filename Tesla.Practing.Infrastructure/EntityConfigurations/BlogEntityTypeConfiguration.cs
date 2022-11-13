using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Practing.Domain.AggregatesModel.BlogAggregates;
using Tesla.Practing.Domain.AggregatesModel.OrderAggregates;

namespace Tesla.Practing.Infrastructure.EntityConfigurations
{
    //internal class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    //{
    //    public void Configure(EntityTypeBuilder<Blog> builder)
    //    {
    //        builder.ToTable("blogs");
    //        builder.Property(p => p.Url).IsRequired();
    //        builder.Property(p => p.Rating).HasDefaultValue(3);
    //        builder.Property(p => p.TimeStamp).IsRowVersion();
    //        builder.Property<DateTime>("LastUpdated");
    //        //builder.Property(p => p.Created).HasDefaultValueSql("GETDATE()");
    //    }
    //}
}
