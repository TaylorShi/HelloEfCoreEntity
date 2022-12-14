using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Tasla.Snowflake.Console.Extensions;

namespace Tasla.Snowflake.Console
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
            services.AddSnowflakeServices(configurationRoot);
            System.Console.WriteLine("ReadyDatabase");
            var taskAddBlog = services.AddBlog();
            Task.WhenAll(taskAddBlog).Wait();
            System.Console.WriteLine("AddBlog");
            System.Console.ReadKey();
        }
    }
}
