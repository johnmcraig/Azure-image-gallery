# Simple-Image-Gallery
## A Web App that you can uplaod images, like an Imgur Clone
An image gallery that connects to a Azure storage blob where all images uploaded are saved.

## Tools Used:

1. C#/ASP.NET Core 2.0.3.
2. SQL Database using Entity Framework to create migrations.
3. Azure Blob Storage.
4. CSS3 - some styling from a basic default App template.

## Azure Connection
You need a connection string from your Azure storage account that needs to be linked in the User Secrets.

# Known Issues:

## Bug for deleting images from Database
1. DeleteImage method in ImageServices.cs on line 59 where a Foreign Key Id for Image Tags will not allow the image to be deleted.

# Future Features to be Implemented

- A Search Query to find images by Title and Tag strings.
- Pagination - Page numbers on the gallery if it gets to large.
- Be able to edit tags.

### Thanks where thanks need to be Credited

1. Wes Doyle - A freelance developer who has a tutorial to get started on this project from scratch.
2. Jeff Ammos - instructor of CCA LEarn, a bootcamp I attended for six months, who helped guide me on this application.

