using CodeShopWarehouse.Business;
using CodeShopWarehouse.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CodeShopWarehouse.Web1.Models;

namespace CodeShopWarehouse.Web1
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
            services.AddMvc();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IOrdersRepo, OrdersRepo>();

            services.AddDbContext<CodeShopWarehouseWeb1Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CodeShopWarehouseWeb1Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(o =>
            {
                o.MapRoute(
                    name: "default",
                    template: "{controller=OrdersView}/{action=Index}/{id?}"
                );
            });

        }
    }
}