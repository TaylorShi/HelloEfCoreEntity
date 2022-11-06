using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.EntityConfigurations;

namespace Tesla.Gooding.Infrastructure.Contexts
{
    /// <summary>
    /// 商品副上下文
    /// </summary>
    public class GoodingSlaveContext : DbContext
    {
        public GoodingSlaveContext(DbContextOptions<GoodingSlaveContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
