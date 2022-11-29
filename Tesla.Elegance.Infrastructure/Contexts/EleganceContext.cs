using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Elegance.Domain;

namespace Tesla.Elegance.Infrastructure.Contexts
{
    /// <summary>
    /// 优雅上下文
    /// </summary>
    public class EleganceContext : DbContext
    {
        private readonly EntityInfo _entityInfo;

        public EleganceContext(DbContextOptions<EleganceContext> options, EntityInfo entityInfo) : base(options)
        {
            _entityInfo = entityInfo;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasCharSet("utf8mb4");
            var (Assembly, Types) = _entityInfo.EntitiesInfo;
            //循环实体类型，并且通过Entity方法注册类型
            foreach (var entityType in Types)
            {
                modelBuilder.Entity(entityType);
            }
            //只需要将配置类所在的程序集给到，它会自动加载
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
