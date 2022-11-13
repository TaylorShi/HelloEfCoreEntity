using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Tesla.Framework.Domain.Abstractions.BarcodeBuilders;
using Tesla.Framework.Domain.Abstractions.IdBuilders;
using Tesla.Framework.Domain.Abstractions.IdBuilders.Extensions;
using Tesla.Framework.Domain.Abstractions.VersionBuilders;
using Tesla.Framework.Infrastructure.Core.Algorithms.Snowflake;
using Tesla.Practing.Domain.AggregatesModel.BlogAggregates;
using Tesla.Practing.Infrastructure.Contexts;

namespace Tasla.Querying.Console
{
    internal class Program
    {
        private static ServiceCollection services;

        static void Main(string[] args)
        {
            ReadyDatabase();
            System.Console.WriteLine("ReadyDatabase");
            var taskAddBlog = AddBlog();
            Task.WhenAll(taskAddBlog).Wait();
            System.Console.WriteLine("AddBlog");
            System.Console.ReadKey();
        }

        private static void ReadyDatabase()
        {
            // 创建配置构建器
            IConfigurationBuilder builder = new ConfigurationBuilder();
            // 添加Json文件数据源
            builder.AddJsonFile("appsettings.json");
            // 构建配置获取配置根
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot["MYSQL"];

            var serverVersion = new MySqlServerVersion(new Version(5, 7, 40));

            services = new ServiceCollection();
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

            services.AddDbContext<PractingContext>(opt =>
                opt.UseMySql(connectionString, serverVersion)
                // 日志输出到控制台
                .LogTo(System.Console.WriteLine, LogLevel.Error)
                .EnableSensitiveDataLogging(true)
                // 日志输出记录详细异常
                .EnableDetailedErrors()
            ); ;

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<PractingContext>();
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        private static async Task AddBlog()
        {
            for (int i = 0; i < 1; i++)
            {
                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<PractingContext>();

                    var blog = new Blog("https://www.cnblogs.com/taylorshi/p/16884860.html");
                    context.Blogs.Add(blog);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
