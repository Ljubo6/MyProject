using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICar.Data;
using ICar.Data.Intrfaces;
using ICar.Data.Mocks;
using ICar.Data.Models;
using ICar.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ICar
{
    public class Startup
    {

        private IConfigurationRoot _confstring;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbSettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));



            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routs =>
            {
                routs.MapRoute(name:"default",template:"{controller=Home}/{action=Index}/{id?}");
                routs.MapRoute(name:"categoryFilter",template:"Car/{action}/{category?}",defaults: new { Controller="Car",action="List"});
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbObjects.Initial(context);
            }

        }
    }
}
