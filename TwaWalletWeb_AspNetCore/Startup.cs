using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TwaWalletWeb_AspNetCore.Models;

namespace TwaWalletWeb_AspNetCore
{

    /// <summary>
    /// MVC app (nejedná se o Razor app)
    /// jeď podle tohoto tutorialu, ale udělej to na MODEL dle TwaWallet
    /// TODO: pokračuj v kapitole:
    /// TODO: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?tabs=aspnetcore2x
    /// </summary>
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

            services.AddDbContext<TwaWalletWeb_AspNetCoreContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TwaWalletWeb_AspNetCoreContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    // /[Controller]/[ActionName]/[Parameters]
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
