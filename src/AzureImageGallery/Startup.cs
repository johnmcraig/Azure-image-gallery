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
            services.AddMvc();

            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:connectionString"]);
            });

            //services.AddIdentity<AppUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AzureImageGalleryDbContext>()
            //    .AddDefaultTokenProviders();

            //services.AddAuthentication();

            //var builder = services.AddIdentityCore<AppUser>();
            //var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            //identityBuilder.AddEntityFrameworkStores<AzureImageGalleryDbContext>();
            //identityBuilder.AddSignInManager<SignInManager<AppUser>>();

        }

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

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            //app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
