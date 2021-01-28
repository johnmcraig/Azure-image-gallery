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

Azure-Image-Gallery is an N-tier project that contains three major project layers: the MVC web application contained in `AzureImageGallery.Web`, database configuration, interfaces, and entities in the `AzureImageGallery.Data`, and a business logic service layer to complete operations in the `AzureImageGallery.Service` directory.  

## Setup and Download

In order to use this application:

1. Download a zip file or clone the repository.

```bash
~$ git clone https://github.com/johnmcraig/azure-image-gallery
```

2. Then, gather any missing NuGet packages and restore the project files using the DotNet command `dotnet restore` (or Build in Visual Studio).

3. Afterwards, you will need to have an Azure account that has a Blob Storage service. Get the connection string from the account info under Access Keys, then pass them in the User Secrets or Application settings JSON file as:
`{ "AzureStorageConnectionString": "YourActualKey" }`.

    Additionally, if you do not have an `appsettings.json` file, you will need to create one.

1. Make sure you use either Visual Studio Secret Manager or the `dotnet` command line to add the above JSON object (from point #3.) so the CloudStorage class and methods can connect using that string.

2. Obtain the `insertImages.sql`, found in the `AzureImageGallery.Data` project, and use the INSERT command to setup two test images contained in the `wwwroot` directory of the web project.

### The required NuGet Packages

- Microsoft.Extensions.SecretManager.Tools
- WindowsAzure.Storage (This was deprecated and the suggested package is Azure.Storage.Blobs v12+, working on a fix)
- Microsoft.EntityFrameworkCore.Design

## Technologies

- C#/ASP.NET Core 3.1.1
- SQL Server Database with Entity Framework Core ORM
- Azure Blob Storage
- HTML5, CSS3, and Bootstrap 4.3.1

## Future Features to be Implemented

- User Roles
- Admin Panel
- Able to edit tags
