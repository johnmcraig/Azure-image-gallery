using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace AzureImageGallery.Data
{
    public static class MigrationManager
    {
        private static readonly ILogger _logger;

        public static IHost MigratDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider
                    .GetRequiredService<AzureImageGalleryDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation($"{ex}");
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
