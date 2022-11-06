using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tesla.Gooding.Application.Extensions;
using Tesla.Gooding.Interface.ExceptionFilters;
using Tesla.Gooding.Interface.Extensions;

namespace Tesla.Gooding.Interface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // 添加和配置异常过滤
            services.AddMvc(mvcOptions =>
            {
                mvcOptions.Filters.Add<TeslaExceptionFilterAtttribute>();
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });
            // 添加和配置API版本相关服务
            services.AddApiVersions();
            // 添加和配置Swagger相关服务
            services.AddSwaggers();
            // 添加命令处理服务
            services.AddCommandHandlers();
            // 添加MYSQL集群上下文服务
            services.AddMySqlClusterContext(Configuration.GetValue<string>("MYSQL-Master"), Configuration.GetValue<string>("MYSQL-Slave"));
            // 添加所有仓储服务
            services.AddRepositories();
            // 添加程序集映射配置
            services.AddAssemblyMapppers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseEfEnsureCreated();

            app.UseSwaggerAndApiVersions(provider);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
