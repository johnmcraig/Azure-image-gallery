using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    //<summary> 
    //This is a 1:1 mapping of the GelleryImage Object in SimpleImaeGellery.Data
    //<summary>
namespace SimpleImageGallery.Models
{
    public class GalleryDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        public List<string> Tags { get; set; }
    }
}
