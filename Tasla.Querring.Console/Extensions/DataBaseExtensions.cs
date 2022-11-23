using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Tesla.Practing.Infrastructure.Contexts;

namespace Tasla.Querring.Console.Extensions
{
    internal static class DataBaseExtensions
    {
        public static ServiceCollection AddMYSQLDataBase(this ServiceCollection services, IConfigurationRoot configurationRoot)
        {
            var connectionString = configurationRoot["MYSQL"];
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 40));

            services.AddDbContext<PractingContext>(opt =>
                opt.UseMySql(connectionString, serverVersion)
                // 日志输出到控制台
                .LogTo(System.Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                // 日志输出记录详细异常
                .EnableDetailedErrors()
            );

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<PractingContext>();
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return services;
        }
    }
}
