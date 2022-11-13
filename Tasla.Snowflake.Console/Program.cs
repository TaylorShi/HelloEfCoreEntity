using Microsoft.Extensions.DependencyInjection;
using System;
using Tesla.Framework.Domain.Abstractions.IdBuilders;
using Tesla.Framework.Infrastructure.Core.Algorithms.Snowflake;

namespace Tasla.Snowflake.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            //services.AddSingleton<IIdWorker>(new IdWorker(1, 1));
            //var serverProvider = services.BuildServiceProvider();
            //var idWorker = serverProvider.GetService<IIdWorker>();
            //for (int i = 0; i < 10; i++)
            //{
            //    System.Console.WriteLine($"ID：{idWorker.NextId()}");
            //}

            //services.AddSingleton<IIdWorker>(new DistributedIdWorker());
            //var serverProvider = services.BuildServiceProvider();
            //var idWorker = serverProvider.GetService<IIdWorker>();
            //for (int i = 0; i < 10; i++)
            //{
            //    System.Console.WriteLine($"ID：{idWorker.NextId()}");
            //}

            //services.AddSingleton<IIdWorker>(new DistributedIdWorker(new TestSnowflakeRuler()));
            //var serverProvider = services.BuildServiceProvider();
            //var idWorker = serverProvider.GetService<IIdWorker>();
            //for (int i = 0; i < 10; i++)
            //{
            //    System.Console.WriteLine($"ID：{idWorker.NextId()}");
            //}

            System.Console.ReadKey();
        }
    }
}
