using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tesla.Gooding.Application.Commands;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Contexts;

namespace Tesla.Gooding.Application.Extensions
{
    /// <summary>
    /// 命令处理扩展
    /// </summary>
    public static class CommandHandlerExtensions
    {
        /// <summary>
        /// 添加命令处理服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(GoodingContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Brand).Assembly, typeof(CreateBrandCommand).Assembly);
        }
    }
}
