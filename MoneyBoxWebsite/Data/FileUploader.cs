namespace MoneyBoxWebsite.Data
{
    public static class FileUploader
    {
        /// <summary>
        /// Upload an image file on the server. Upload folder : wwwroot/images.
        /// </summary>
        /// <param name="imageFile">The image to upload.</param>
        /// <returns>The path where the image is saved.</returns>
        public static string UploadImage(IFormFile imageFile)
        {
            if(imageFile != null && imageFile.Length > 0)
            {
                // Rename the file before inserting into the folder
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                // Specify where to insert the new file
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                Console.WriteLine(" \n \n Image file path" + filePath + "\n \n");

                // Upload file on the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                return fileName;
            }


            return ""; // In case any error occured
        }
    }
}
