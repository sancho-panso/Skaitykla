using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Skaitykla._EF;
using Skaitykla.MVC.Models;
using Skaitykla.MVC.Services;
using Skaitykla.Services;
using Skaitykla.Services.Interfaces;

namespace Skaitykla.MVC
{
    public class Startup
    {
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookContext>();
            services.AddTransient<IAuthorService, AuthorServices>();
            services.AddTransient<IBookService, BookServices>();
            services.AddTransient<ILendingService, LendingServices>();
            services.AddTransient<IUserService, UserService>();
            services.AddMvc();
            //services.AddSingleton<InMemoryUserData>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
