using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options => { options.EnableSensitiveDataLogging(true); options.UseSqlServer(conString); });
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IPurchaseRepository, EFPurchaseRepository>();
            services.AddTransient<IContragentRepository, EFContrageltRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseMvc(routes => {
                    routes.MapRoute(
                        name: null,
                        template: "{category}/Page{prPage}",
                        defaults: new { Controller = "Product", Action = "List"});

                    routes.MapRoute(
                        name: null,
                        template: "Page{prPage:int}",
                        defaults: new { Controller = "Product", Action = "List", category = "" });

                    routes.MapRoute(
                        name: null,
                        template: "{category}",
                        defaults: new { Controller = "Product", Action = "List", prPage = 1 });

                    routes.MapRoute(
                        name: null,
                        template: "",
                        defaults: new { Controller = "Purchase", Action = "Purchase", period = 1, periodNum = 1 });

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Product}/{action=List}/{id?}");
                });
            }

            SeedData.EnsurePopulated(app);
        }
    }
}
