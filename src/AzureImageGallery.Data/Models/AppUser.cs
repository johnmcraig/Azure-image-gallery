using System;
using Microsoft.AspNetCore.Identity;

namespace AzureImageGallery.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
    }
}