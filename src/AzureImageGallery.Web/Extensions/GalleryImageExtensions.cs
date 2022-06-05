using System.Linq;
using AzureImageGallery.Data.Models;

namespace AzureImageGallery.Web.Extensions
{
    public static class GalleryImageExtensions
    {
        public static IQueryable<GalleryImage> Sort(this IQueryable<GalleryImage> query, string orderBy)
        {
            if(string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(i => i.Title);

            query = orderBy switch
            {
                "date" => query.OrderBy(i => i.Created),
                _ => query.OrderBy(i => i.Title)
            };

            return query;
        }
    }
}