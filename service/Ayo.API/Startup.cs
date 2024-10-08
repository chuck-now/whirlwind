using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.IO;
using BaseLib;
using Ayo.API.Filters;
using Ayo.Core.Configuration;

namespace Ayo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var appOptions = BaseLibEngine.Instance.Resolve<AppOptions>();
            services.AddCors(options =>
            {
                options.AddPolicy("ayo-policy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .WithMethods("POST", "GET", "OPTIONS");
                    });
            });

            services.AddMvc(options =>
            {
                //filters
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{appOptions.Name}：AyoAPI【智能采集系统-哎呦】",
                    Description = "智能采集系统实战"
                });

                var basePath = Directory.GetCurrentDirectory();
                options.IncludeXmlComments(Path.Combine(basePath, "Ayo.Core.xml"));
                options.IncludeXmlComments(Path.Combine(basePath, "Ayo.API.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //在不执行EnableBuffering(HttpRequest)来缓存Body的情况下，Body只能被读取一次。
            app.Use(next => new RequestDelegate(
            async context =>
            {
                context.Request.EnableBuffering();
                await next(context);
            }));

            var appOptions = BaseLibEngine.Instance.Resolve<AppOptions>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("ayo-policy");

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
                RequestPath = "/static",
                EnableDirectoryBrowsing = false
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/static/swagger/v1/swagger.json", appOptions.Name);
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}