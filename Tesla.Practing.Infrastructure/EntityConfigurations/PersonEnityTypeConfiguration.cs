using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Practing.Domain.AggregatesModel.OrderAggregates;
using Tesla.Practing.Domain.AggregatesModel.PersonAggregates;

namespace Tesla.Practing.Infrastructure.EntityConfigurations
{
    internal class PersonEnityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //builder.Property(p => p.DisplayName).HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
        }
    }
}
