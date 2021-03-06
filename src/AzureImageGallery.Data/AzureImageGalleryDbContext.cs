﻿using Microsoft.EntityFrameworkCore;
using AzureImageGallery.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using AzureImageGallery.Data.Configuration;

namespace AzureImageGallery.Data
{
    public class AzureImageGalleryDbContext : 
        IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AzureImageGalleryDbContext(DbContextOptions<AzureImageGalleryDbContext> options) 
            : base(options)
        {
        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GalleryImageConfiguration());
        }
    }
}
