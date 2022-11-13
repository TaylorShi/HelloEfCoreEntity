using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Practing.Domain.AggregatesModel.BlogAggregates;

namespace Tesla.Practing.Infrastructure.EntityConfigurations
{
    internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(b => b.DateCreated).ValueGeneratedOnAdd();
            builder.Property(b => b.DateModifyed).ValueGeneratedOnAddOrUpdate();
        }
    }
}
