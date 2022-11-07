using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesla.Framework.Infrastructure.Core.Contexts;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.EntityConfigurations;

namespace Tesla.Gooding.Infrastructure.Contexts
{
    /// <summary>
    /// 商品主上下文
    /// </summary>
    public class GoodingMasterContext : EFContext
    {
        public GoodingMasterContext(DbContextOptions<GoodingMasterContext> options, IMediator mediator) : base(options, mediator)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        //public DbSet<BrandImage> BrandImages { get; set; }

        //public DbSet<BrandUrl> BrandUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandImageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandUrlEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
