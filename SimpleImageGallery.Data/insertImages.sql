/* 
After making a migration and updating the databse through EF, 
run this command to make an insert of two images from 
the wwwroot images directory
*/
SELECT * FROM GalleryImages
INSERT INTO GalleryImages(Created, Title, [Url]) VALUES
(GETDATE(), 'Boat one', '/images/boat1.jpeg'),
(GETDATE(), 'Baot two', '/images/boat2.jpeg')