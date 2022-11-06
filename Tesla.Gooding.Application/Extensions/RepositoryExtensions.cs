using Microsoft.Extensions.DependencyInjection;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Extensions
{
    /// <summary>
    /// 仓储服务扩展
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        /// 添加所有仓储服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // 注册代码仓储(作用域模式)
            services.AddScoped<IBrandRepository, BrandRepository>();
            return services;
        }
    }
}
