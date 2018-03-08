using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleImageGallery.Helpers
{
    public class GalleryParams
    {
        private const int MaxPageSize = 72;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 36;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

    }
}
