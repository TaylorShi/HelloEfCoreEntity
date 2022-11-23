using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tesla.Practing.Domain.AggregatesModel.BlogAggregates;
using Tesla.Practing.Infrastructure.Contexts;

namespace Tasla.Snowflake.Console.Extensions
{
    internal static class ContextExtensions
    {
        public static async Task AddBlog(this ServiceCollection services)
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
