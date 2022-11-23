using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tesla.Framework.Domain.Abstractions.IdBuilders.Extensions;
using Tesla.Framework.Domain.Abstractions.IdBuilders;
using Tesla.Framework.Domain.Abstractions.VersionBuilders;
using Tesla.Framework.Infrastructure.Core.Algorithms.Snowflake;

namespace Tasla.Snowflake.Console.Extensions
{
    internal static class SnowflakeExtensions
    {
        public static ServiceCollection AddSnowflakeServices(this ServiceCollection services, IConfigurationRoot configurationRoot)
        {
            // 雪花算法ID生成
            services.AddOptions<SnowflakeOptions>().Configure(options =>
            {
                configurationRoot.GetSection("Snowflake").Bind(options);
            });
            //services.AddSingleton<IIdWorker, DistributedIdWorker>();
            services.AddSingleton<IGenerateProvider, SnowflakeGenerateProvider>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var generateProvider = scope.ServiceProvider.GetService<IGenerateProvider>();
                System.Console.WriteLine($"SnowflakeId: {generateProvider.GenerateId()}");
            }

            //services.AddSingleton(typeof(IIdBuilder<,>), typeof(IdBuilder<,>));
            var serviceProvider = services.BuildServiceProvider();
            RegisterIdExtension.RegisterIdFunc(() => serviceProvider.GetService<IGenerateProvider>().GenerateId());

            services.AddSingleton(typeof(IVersionNoBuilder<>), typeof(VersionNoBuilder<>));

            //var versionNo = services.BuildServiceProvider().GetService<IVersionNoBuilder<Blog>>().CreateVersionNo();
            //System.Console.WriteLine(versionNo);
            //var idInfo = versionNo.GetIdInformation();

            //services.AddSingleton<IOrderBarCodeBuilder, OrderBarCodeBuilder>();
            //var orderBarcode = services.BuildServiceProvider().GetService<IOrderBarCodeBuilder>().Build(10018);
            //System.Console.WriteLine(orderBarcode);

            return services;
        }

    }
}
