
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Tesla.Elegance.Domain;
using Tesla.Elegance.Domain.Abstractions;
using Tesla.Elegance.Infrastructure.Contexts;
using Tesla.Elegance.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Extensions
{
    /// <summary>
    /// EF上下文扩展
    /// </summary>
    public static class EFContextExtensions
    {
        /// <summary>
        /// 添加MYSQL集群上下文服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="masterConnectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddMySqlClusterContext(this IServiceCollection services, string masterConnectionString)
        {
            services.AddSingleton<EntityInfo>();
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(GenericRepository<,>));

            var serverVersion = new MySqlServerVersion(new Version(5, 7, 40));

            // 添加主上下文
            services.AddDbContext<EleganceContext>(optionsAction =>
            {
                optionsAction.UseMySql(masterConnectionString, serverVersion, options =>
                {
                    options.EnableRetryOnFailure
                    (
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: new List<int> { 0 }
                    );
                    options.MigrationsAssembly("Tesla.Elegance.Interface");
                })
                // 根据日志级别输出到控制台
                .LogTo(Console.WriteLine, LogLevel.Information)
                // 日志输出记录敏感数据
                .EnableSensitiveDataLogging()
                // 日志输出记录详细异常
                .EnableDetailedErrors();
            });

            return services;
        }
    }
}
