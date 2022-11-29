using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Elegance.Domain.AggregatesModel.UserAggregates;

namespace Tesla.Elegance.Infrastructure.EntityConfigurations
{
    public class UserConfig : EntityTypeConfiguration<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UserName).HasMaxLength(50);
            //mock一条数据
            builder.HasData(new User()
            {
                UserName = "Bruce",
                Birthday = DateTime.Parse("1996-08-24")
            });
        }
    }

}
