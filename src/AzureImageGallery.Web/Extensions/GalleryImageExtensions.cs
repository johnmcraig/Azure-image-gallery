using System.Collections.Generic;
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
                "dateDecs" => query.OrderByDescending(i => i.Created),
                _ => query.OrderBy(i => i.Title)
            };

            return query;
        }

        public static IQueryable<GalleryImage> Search(this IQueryable<GalleryImage> query, string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            
            return query.Where(i => i.Title.ToLower().Contains(searchTerm));
        }

        public static IQueryable<GalleryImage> Filter(this IQueryable<GalleryImage> query, string tags)
        {
            var imageList = new List<string>();

            if(!string.IsNullOrEmpty(tags))
                imageList.AddRange(tags.ToLower().Split(", ").ToList());

            query = query.Where(i => imageList.Count == 0 || imageList.Contains(i.Tags.ToString().ToLower()));

            return query;
        }
    }
}