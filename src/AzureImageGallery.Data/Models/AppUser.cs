using System;
using Microsoft.AspNetCore.Identity;

namespace AzureImageGallery.Data.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}