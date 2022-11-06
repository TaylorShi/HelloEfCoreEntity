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
            // ��Ӻ������쳣����
            services.AddMvc(mvcOptions =>
            {
                mvcOptions.Filters.Add<TeslaExceptionFilterAtttribute>();
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });
            // ��Ӻ�����API�汾��ط���
            services.AddApiVersions();
            // ��Ӻ�����Swagger��ط���
            services.AddSwaggers();
            // �����������
            services.AddCommandHandlers();
            // ���MYSQL��Ⱥ�����ķ���
            services.AddMySqlClusterContext(Configuration.GetValue<string>("MYSQL-Master"), Configuration.GetValue<string>("MYSQL-Slave"));
            // ������вִ�����
            services.AddRepositories();
            // ��ӳ���ӳ������
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
