using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography.X509Certificates;
using Tesla.Practing.Domain.AggregatesModel.PassportAggregates;

namespace Tesla.Practing.Infrastructure.EntityConfigurations
{
    internal class PassportEnityTypeConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.ToTable("passports");
            builder.HasKey(x => new { x.PassportNumber, x.IssuingCountry });
        }
    }
}
