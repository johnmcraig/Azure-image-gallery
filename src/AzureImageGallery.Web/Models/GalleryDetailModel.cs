using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//<summary> 
//This is a 1:1 mapping of the GalleryImage Object in SimpleImageGallery.Data
//<summary>
namespace AzureImageGallery.Web.Models
{
    public class GalleryDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public string Url { get; set; }

        public List<string> Tags { get; set; }
    }
}
