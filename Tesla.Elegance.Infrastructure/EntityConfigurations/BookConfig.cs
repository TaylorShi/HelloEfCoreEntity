using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Elegance.Domain.AggregatesModel.BookAggregates;

namespace Tesla.Elegance.Infrastructure.EntityConfigurations
{
    public class BookConfig : EntityTypeConfiguration<Book, Guid>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id).ValueGeneratedOnAdd(); //设置book的id自增
            builder.Property(x => x.BookName).HasMaxLength(500).IsRequired();
            builder.HasIndex(x => x.Author);//作者添加索引
            builder.HasIndex(x => x.SN).IsUnique();//序列号添加唯一索引
            builder.HasOne(r => r.User).WithMany(x => x.Books)
                .HasForeignKey(r => r.UserId).IsRequired(false);//导航属性，本质就是创建外键，虽然查询很方便，生产中不建议使用！！！
        }
    }

}
