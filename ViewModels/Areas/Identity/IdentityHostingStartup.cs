using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViewModels.DataAccess;

[assembly: HostingStartup(typeof(ViewModels.Areas.Identity.IdentityHostingStartup))]
namespace ViewModels.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                /*
                services.AddDbContext<ViewModelsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ViewModelsContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ViewModelsContext>();
                    */
            });
        }
    }
}