using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tesla.Gooding.Application.Extensions
{
    /// <summary>
    /// 自动映射扩展
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// 添加程序集映射配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAssemblyMapppers(this IServiceCollection services)
        {
            return services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
