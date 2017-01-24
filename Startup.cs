using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using DotNetGroupTalk.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetGroupTalk
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductContext>(opt=>{
                var connectstring = Configuration.GetConnectionString("DefaultConnection");
                opt.UseSqlServer(connectstring);
            });
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app,IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
                Seed.Seedit(app.ApplicationServices);

            }

            app.UseStaticFiles();


            app.UseMvc(
                routes=>{
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                }
            );

        }
    }


}