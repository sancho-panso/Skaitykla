using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skaitykla.MVC;
using Skaitykla.MVC.Data;

[assembly: HostingStartup(typeof(Skaitykla.MVC.Areas.Identity.IdentityHostingStartup))]
namespace Skaitykla.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserIdentityContextConnection")));

                services.AddDefaultIdentity<LibraryUser>(options =>
                options.SignIn.RequireConfirmedEmail = false)
                    .AddEntityFrameworkStores<UserIdentityContext>();
            });
        }
    }
}