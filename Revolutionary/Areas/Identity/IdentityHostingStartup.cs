using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Revolutionary.Areas.Identity.Data.Contexts;
using Revolutionary.Areas.Identity.Data.Models;
using Revolutionary.Areas.Identity.Data.Services;

[assembly: HostingStartup(typeof(Revolutionary.Areas.Identity.IdentityHostingStartup))]
namespace Revolutionary.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthenticationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthenticationConnection")));

                services.AddIdentity<User, Role>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = false;
                }).AddEntityFrameworkStores<AuthenticationContext>().AddDefaultTokenProviders();

                services.AddTransient<IEmailSender, EmailSender>();
            });
        }
    }
}