using BLL.Servises;
using BLL.Struct;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                });
            });
            services.AddControllersWithViews();
            /*//var kernel = new StandardKernel();
            //kernel.Bind
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            NinjectModule orderModule = new OrderModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection3");

            //services.AddScoped<OrderService, OrderModule>();
            //services.AddSingleton<IOrderService, OrderService>();
            //services.AddSingleton<NinjectModule, ServiceModule>();
            List<INinjectModule> ninjectModules = new List<INinjectModule>()
                   {
                       new OrderModule(),
                       new ServiceModule("DefaultConnection3")
                    };
            //var kernel = new StandardKernel();
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
