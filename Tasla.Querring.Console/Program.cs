using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasla.Querring.Console.Extensions;

namespace Tasla.Querring.Console
{
    internal class Program
    {
        private static ServiceCollection services;
        private static IConfigurationRoot configurationRoot;

        static void Main(string[] args)
        {
            configurationRoot = ConfigHelper.GetConfigurationRoot();
            services = new ServiceCollection();
            services.AddMYSQLDataBase(configurationRoot);
            services.BuildServiceProvider().AddSimpleQuerings();
            System.Console.ReadKey();
        }
    }
}
