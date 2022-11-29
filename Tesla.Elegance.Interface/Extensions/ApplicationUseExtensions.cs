using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Tesla.Elegance.Domain.Abstractions;
using Tesla.Elegance.Domain.AggregatesModel.BookAggregates;
using Tesla.Elegance.Domain.AggregatesModel.UserAggregates;
using Tesla.Elegance.Infrastructure.Contexts;

namespace Tesla.Gooding.Interface.Extensions
{
    /// <summary>
    /// 应用启用扩展
    /// </summary>
    public static class ApplicationUseExtensions
    {
        /// <summary>
        /// 使用EF确保创建
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseEfEnsureCreated(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dc = scope.ServiceProvider.GetService<EleganceContext>();
                dc.Database.EnsureCreated();

                dc.Add(new User { UserName = "xxxsss", Books = new List<Book>() { new Book { SN = "2" } } });
                dc.SaveChanges();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var asyncRepository = scope.ServiceProvider.GetService<IAsyncRepository<User, Guid>>();
                var users = asyncRepository.Where(x => x.UserName.Contains("xx")).ToList();
            }
            
            return app;
        }
    }
}
