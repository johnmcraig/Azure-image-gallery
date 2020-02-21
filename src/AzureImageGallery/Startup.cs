using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AzureImageGallery.Data;
using Microsoft.EntityFrameworkCore;
using AzureImageGallery.Services;
using AzureImageGallery.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;

namespace SimpleImageGallery
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
            services.AddDbContext<AzureImageGalleryDbContext>(options =>
                options.UseSqlServer(Configuration
                .GetConnectionString("DefaultConnection")));

            services.AddScoped<IImage, ImageService>();

            services.AddControllersWithViews();

            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:connectionString"]);
            });

            services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<AzureImageGalleryDbContext>()
               .AddSignInManager<SignInManager<AppUser>>()
               .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/Login";
            });

            services.AddAuthentication();

            // var builder = services.AddIdentityCore<AppUser>();
            // var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            // identityBuilder.AddEntityFrameworkStores<AzureImageGalleryDbContext>();
            // identityBuilder.AddSignInManager<SignInManager<AppUser>>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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
