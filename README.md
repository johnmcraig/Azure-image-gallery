# Simple-Image-Gallery
## A Web App that you can uplaod images!
An image gallery as a web application using ASP.Net Core 2.0 that connects to an Azure storage blob, where all uploaded images are saved. Images have full CRUD functionality.

## Setup and Download

In order to use this application:
1. Downlaod the zip file or `git clone` the repo.
2. Then, gather any missing NuGet packages and restore the project files using the DotNet command `restore` (or Build in Visiaul Studio). 
3. Afterwards, you will need to have an Azure account that has initialized Blob Storage. Get the connection string from the account info under keys, then pass them in the User Secrets as:      
`{ "AzureStorageConnectionString": AzureAddressKey }` .

## Tools Used:

1. C#/ASP.NET Core 2.0.3.
2. SQL Database with Entity Framework as the ORM.
3. Azure Blob Storage.
4. CSS3 - some styling from a basic default App template.

## Known Issues:

1. Bug for deleting images from Database has now been fixed. Follow how the process [here](https://github.com/johnmcraig/Simple-Image-Gallery/issues/1).
2. SimpleImageGallery.Data.csproj solution was missing a package reference for Windows Azure Storage and version. It has now been corrected with the latest push as of 3/08/2018.

# Future Features to be Implemented

- A Search Query to find images by Title and Tag strings.
- Pagination - Page numbers on the gallery if it gets larger.
- Able to edit tags.
- User Login and Add Roles to those users.

### Thanks where thanks need to be Credited

1. Wes Doyle - A freelance developer who has a tutorial to get started on this project from scratch.
2. Jeff Ammos - instructor of CCALearn, a bootcamp I attended for six months, who helped guide me on this application.

