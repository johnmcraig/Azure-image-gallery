using Microsoft.WindowsAzure.Storage.Blob;
using AzureImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureImageGallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();

        IEnumerable<GalleryImage> GetWithTag(string tag);

        GalleryImage GetById(int id);

        CloudBlobContainer GetBlobContainer(string connection, string containerName);

        Task SetImage(string title, string tags, Uri uri);

        List<ImageTag> ParseTags(string tags);

        IEnumerable<GalleryImage> Range(int skip, int take);

        void UpdateImage(GalleryImage changeImage);

        void DeleteImage(GalleryImage imageToDelete);
    }
}
