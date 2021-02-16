<h1 align="center">

Azure Image Gallery

</h1>

<div align="center">

![visitors](https://vistr.dev/badge?repo=johnmcraig.Azure-image-gallery)
![stars](https://img.shields.io/github/stars/johnmcraig/Azure-image-gallery?style=flat-square&cacheSeconds=604800)
![last commit](https://img.shields.io/github/last-commit/johnmcraig/Azure-image-gallery?style=flat-square&cacheSeconds=86400)
![pull requests](https://img.shields.io/github/issues-pr/johnmcraig/Azure-image-gallery?color=0088ff)

</div>

<div align="center">

> An image gallery with file hosting on Azure Blob Storage

</div>

![Screenshot](resources/ImageGallery.png)

## Demo

See a demo of the application at the following link: [AzureImageGallery](https://azureimagegallery.azurewebsites.net/)

## Scope

This is a full stack application using C#/ASP.Net Core as an image gallery that uploads and reads files to an Azure blob storage container. Images have full create, edit, and delete functionality.

A SQL database reads an Uri to the actual file in the container of the storage service and serves it via web view, thus reducing space (and cost) needed in a relational database.

## Project Structure

Azure-Image-Gallery is an N-tier project that contains three major project layers:

- The MVC web application contained in `AzureImageGallery.Web`.
- Database configuration, interfaces, and entities in the `AzureImageGallery.Data`.
- The business logic services layer to complete operations in the `AzureImageGallery.Services` directory.  

## Features

- Upload images or files and view them by date created.
- Search by title of an image.
- Paging.
- Authentication with Login/Register.

## Setup and Download

In order to use this application:

- Download a zip file or clone the repository.

```bash
~$ git clone https://github.com/johnmcraig/azure-image-gallery
```

- Then, gather any missing NuGet packages and restore the project files using the DotNet command `dotnet restore` (or Build in Visual Studio).

- Afterwards, you will need to have an Azure account that has a Blob Storage service. Get the connection string from the account info under Access Keys, then pass them in the User Secrets or Application settings JSON file as:
`{ "AzureStorageConnectionString": "YourActualKey" }`.

    Additionally, if you do not have an `appsettings.json` file, you will need to create one.

- Make sure you use either Visual Studio Secret Manager or the `dotnet` command line to add the above JSON object (from point #3.) so the CloudStorage class and methods can connect using that string.

- Upon initial startup of the application, if it is currently in development mode, a Sqlite database will be created and a few images will be seeded into the database for testing purposes.

## Technologies

- C#/ASP.NET Core MVC --version 3.1
- Sqlite3 Database for Development, SQL Server for product.
- Entity Framework Core as the ORM
- Azure Blob Storage
- HTML5, CSS3, and Bootstrap 4.3.1

### The required NuGet Packages

- Microsoft.EntityFramework.Core
- Azure.Storage.Blobs v12+
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite

## Future Features to be Implemented

- User Roles
- Admin Panel
- Able to edit tags
