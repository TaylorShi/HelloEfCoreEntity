using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Tesla.Practing.Domain.AggregatesModel.BlogAggregates;
using Tesla.Practing.Infrastructure.Contexts;

namespace Tasla.Querring.Console.Extensions
{
    internal static class QuerringExtensions
    {
        public static void AddSimpleQuerings(this ServiceProvider serviceProvider)
        {
            // 加载所有数据
            //using (var context = serviceProvider.GetService<PractingContext>())
            //{
            //    var blogs = context.Blogs.ToList();
            //    blogs.JsonPrint();
            //}

            // 加载单个实体
            //using (var context = serviceProvider.GetService<PractingContext>())
            //{
            //    var blog = context.Blogs.Single(b => b.Id == 3042227260074627078);
            //    blog.JsonPrint();
            //}

            // 筛选
            //using (var context = serviceProvider.GetService<PractingContext>())
            //{
            //    var blogs = context.Blogs
            //        .Where(b => b.Url.Contains("taylorshi"))
            //        .ToList();
            //    blogs.JsonPrint();
            //}

            // 顶级投影中的客户端评估
            //using (var context = serviceProvider.GetService<PractingContext>())
            //{
            //    var blogs = context.Blogs
            //        .OrderByDescending(b=>b.DateCreated)
            //        .Select(b => new { Id = b.Id, Url = StandardizeUrl(b.Url)})
            //        .ToList();

            //    blogs.JsonPrint();
            //}

            // 不支持的客户端评估
            //using (var context = serviceProvider.GetService<PractingContext>())
            //{
            //    var blogs = context.Blogs
            //        .Where(b => StandardizeUrl(b.Url).Contains("taylorshi"))
            //        .ToList();
            //    blogs.JsonPrint();
            //}

            // 显式客户端评估
            //using (var context = serviceProvider.GetService<PractingContext>())
            //{
            //    var blogs = context.Blogs
            //        .AsEnumerable()
            //        .Where(b => StandardizeUrl(b.Url).Contains("taylorshi"))
            //        .ToList();
            //    blogs.JsonPrint();
            //}

        }

        public static string StandardizeUrl(string url)
        {
            url = url.ToLower();

            if (!url.StartsWith("https://"))
            {
                url = string.Concat("https://", url);
            }

            return url;
        }
    }
}
