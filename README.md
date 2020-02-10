# Azure Image Gallery

> Image gallery with file hosting on Azure

![Screenshot](resources/ImageGallery.png)

## Demo

See a demo of the application at the following link: [AzureImageGalleryDemo](https://tinyurl.com/unpbyrp)

## Scope

This is a full stack application using HTML5, CSS3, Bootstrap 4 and C#/ASP.Net Core as an image gallery that stores files to an Azure blob, where all uploaded images are saved. Images have full create, edit, and delete functionality.

## Project Structure

Azure-Image-Gallery contains three major project layers: the web application contained in `AzureImageGallery`, database configuration, interfaces, and entities in the `AzureImageGallery.Data`, and a business logic service layer to complete operations in the `AzureImageGallery.Service` directory.  

## Setup and Download

In order to use this application:

1. Download a zip file or clone the repository.

```bash
~$ git clone https://github.com/johnmcraig/azure-image-gallery
```

2. Then, gather any missing NuGet packages and restore the project files using the DotNet command `dotnet restore` (or Build in Visual Studio).

3. Afterwards, you will need to have an Azure account that has initialized Blob Storage. Get the connection string from the account info under keys, then pass them in the User Secrets as:
`{ "AzureStorageConnectionString": "YourActualKey" }`.

4. Make sure you use either Visual Studio Secret Manager or the `dotnet` command line to add the above JSON object (from point #3.) so the CloudStorage class and methods can connect using that string.

5. Obtain the `insertImages.sql`, found in the `AzureImageGallery.Data` library, and use those commands to setup two test images contained in the `wwwroot` directory of the web project.

### The required NuGet Packages

1. Microsoft.Extensions.SecretManager.Tools
2. WindowsAzure.Storage
3. Microsoft.EntityFrameworkCore.Design

## Technologies

1. C#/ASP.NET Core 2.0.9.
2. SQL Database with Entity Framework.
3. Azure Blob Storage.
4. HTML5, CSS3, and Bootstrap 4.3.1

## Future Features to be Implemented

- User Login and User Roles.
- A Search Query to find images by Title and Tags.
- Able to edit tags.
