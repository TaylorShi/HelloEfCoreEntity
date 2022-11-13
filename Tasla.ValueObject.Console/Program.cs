using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Tesla.Practing.Infrastructure.Contexts;

namespace Tasla.ValueObject.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ImmutableStack<int> ints = ImmutableStack<int>.Empty;
            //for (int i = 0; i < 2; i++)
            //{
            //    ints = ints.Push(i);
            //}
            //foreach (var item in ints)
            //{
            //    System.Console.WriteLine(item);
            //}

            //ImmutableArray<int> int2s = ImmutableArray<int>.Empty;
            //for (int i = 0; i < 2; i++)
            //{
            //    int2s = int2s.Add(i);
            //}
            //foreach (var item in int2s)
            //{
            //    System.Console.WriteLine(item);
            //}

            //ImmutableArray<int> int2s = ImmutableArray<int>.Empty;
            ////List<int> int3s = new List<int>();
            //var task1 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 20; i++)
            //    {
            //        int2s = int2s.Add(i);
            //        //int3s.Add(i);
            //    }
            //});
            //var task2 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 200; i++)
            //    {
            //        int2s = int2s.Add(i);
            //        //int3s.Add(i);
            //    }
            //});
            //var task3 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 2; i++)
            //    {
            //        int2s = int2s.Add(i);
            //        //int3s.Add(i);
            //    }
            //});

            //Task.WhenAll(task1, task2, task3).Wait();

            //foreach (var item in int2s)
            //{
            //    System.Console.WriteLine(item);
            //}

            // 创建配置构建器
            IConfigurationBuilder builder = new ConfigurationBuilder();
            // 添加Json文件数据源
            builder.AddJsonFile("appsettings.json");
            // 构建配置获取配置根
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot["MYSQL"];

            var serverVersion = new MySqlServerVersion(new Version(5, 7, 40));

            var services = new ServiceCollection();

            services.AddDbContext<PractingContext>(opt =>
                opt.UseMySql(connectionString, serverVersion)
                // 日志输出到控制台
                .LogTo(System.Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                // 日志输出记录详细异常
                .EnableDetailedErrors()
            );;

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<PractingContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //var blog = context.Blogs.FirstOrDefaultAsync().Result;
                //blog.Update("https://www.cnblogs.com/taylorshi/p/16862811.html");
                //context.Update(blog);
                ////var blog = new Blog("https://www.cnblogs.com/taylorshi/p/16862811.html");
                ////context.Add(blog);
                //try
                //{
                //    context.SaveChanges();
                //}
                //catch (DbUpdateConcurrencyException ex)
                //{

                //    throw;
                //}

                //var blogDetail = context.BlogDetails.FirstOrDefaultAsync().Result;
                //blogDetail.Modify("Entity Framework Core3", "TaylorShi3");
                ////var blogDetail = new BlogDetail("Entity Framework Core基础篇", "TaylorShi");
                //context.Update(blogDetail);

                //// 在客户端优先时解决乐观并发异常
                //bool saveFailed;
                //do
                //{
                //    saveFailed = false;
                //    try
                //    {
                //        context.SaveChanges();
                //    }
                //    catch (DbUpdateConcurrencyException ex)
                //    {
                //        saveFailed = true;
                //        // 获取抛出DbUpdateConcurrencyException异常的实体
                //        var entry = ex.Entries.Single();
                //        // 如果这个实体状态为已删除
                //        if (entry.State == EntityState.Deleted)
                //        {
                //            // 设置实体的EntityState为Detached，放弃更新或放弃删除抛出异常的实体
                //            entry.State = EntityState.Detached;
                //        }
                //        else
                //        {
                //            // 以Context中的数据覆盖数据中的数据
                //            entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                //        }
                //    }
                //}
                //while (saveFailed);

                //// 通过数据库优先解决乐观并发异常
                //bool saveFailed;
                //do
                //{
                //    saveFailed = false;
                //    try
                //    {
                //        context.SaveChanges();
                //    }
                //    catch (DbUpdateConcurrencyException ex)
                //    {
                //        saveFailed = true;

                //        // 重载数据库的数据覆盖本地Context中的数据
                //        ex.Entries.Single().Reload();
                //    }
                //}
                //while (saveFailed);

                //// 自定义乐观并发异常的解决方案
                //bool saveFailed;
                //do
                //{
                //    saveFailed = false;
                //    try
                //    {
                //        context.SaveChanges();
                //    }
                //    catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                //    {
                //        saveFailed = true;

                //        var entry = ex.Entries.Single();
                //        var currentValues = entry.CurrentValues;
                //        var databaseValues = entry.GetDatabaseValues();

                //        var resolvedValues = databaseValues.Clone();

                //        HaveUserResolveConcurrency(currentValues, databaseValues, resolvedValues);

                //        entry.OriginalValues.SetValues(databaseValues);
                //        entry.CurrentValues.SetValues(resolvedValues);
                //    }
                //}
                //while (saveFailed);

                //// 使用对象自定义乐观并发异常的解决方案
                //bool saveFailed;
                //do
                //{
                //    saveFailed = false;
                //    try
                //    {
                //        context.SaveChanges();
                //    }
                //    catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                //    {
                //        saveFailed = true;

                //        var entry = ex.Entries.Single();
                //        var databaseValues = entry.GetDatabaseValues();
                //        var databaseValuesAsBlogDetail = (BlogDetail)databaseValues.ToObject();

                //        var resolvedValuesAsBlogDetail = (BlogDetail)databaseValues.ToObject();

                //        HaveUserResolveConcurrency((BlogDetail)entry.Entity, databaseValuesAsBlogDetail, resolvedValuesAsBlogDetail);

                //        entry.OriginalValues.SetValues(databaseValues);
                //        entry.CurrentValues.SetValues(resolvedValuesAsBlogDetail);
                //    }
                //}
                //while (saveFailed);
            }
            System.Console.ReadKey();
        }

        //public static void HaveUserResolveConcurrency(DbPropertyValues currentValues, DbPropertyValues databaseValues, DbPropertyValues resolvedValues)
        //{
        //    // Show the current, database, and resolved values to the user and have
        //    // them edit the resolved values to get the correct resolution.
        //}

        //public static void HaveUserResolveConcurrency(BlogDetail entity, BlogDetail databaseValues, BlogDetail resolvedValues)
        //{
        //    // Show the current, database, and resolved values to the user and have
        //    // them update the resolved values to get the correct resolution.
        //}
    }
}
