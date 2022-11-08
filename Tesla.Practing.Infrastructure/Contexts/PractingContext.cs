using Microsoft.EntityFrameworkCore;
using Tesla.Practing.Domain.AggregatesModel.BlogAggregates;
using Tesla.Practing.Domain.AggregatesModel.OrderAggregates;
using Tesla.Practing.Domain.AggregatesModel.PassportAggregates;

namespace Tesla.Practing.Infrastructure.Contexts
{
    /// <summary>
    /// 练习上下文
    /// </summary>
    public class PractingContext : DbContext
    {
        public PractingContext(DbContextOptions<PractingContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<Passport> Passports { get; set; }
        //public DbSet<BlogAsset> BlogAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PractingContext).Assembly);
            //new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            //modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());

            //modelBuilder.Entity<Blogs>()
            //    .ToTable("blog")
            //    .Property(p=>p.Url)
            //    .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
