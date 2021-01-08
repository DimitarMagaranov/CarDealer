namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly ApplicationDbContext db;

        public CloudinaryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<KeyValuePair<string, string>> Upload(Cloudinary cloudinary, IFormFile file)
        {
            KeyValuePair<string, string> imageUrls;

            byte[] destinationImage;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream),
                };

                var result = await cloudinary.UploadAsync(uploadParams);

                var imageUrl = result.Uri.AbsoluteUri;

                var tokens = imageUrl.Split('/');
                var idWithExt = tokens.Last().ToString();
                var publicId = idWithExt.Split('.').First();

                var resizedImageUrl = this.GetResizedImage(cloudinary, publicId);

                imageUrls = new KeyValuePair<string, string>(imageUrl, resizedImageUrl);
            }

            return imageUrls;
        }

        public void Delete(Cloudinary cloudinary, int saleId)
        {
            var urlListOfOriginalSizedImages = this.db.Images
                .Where(x => x.SaleId == saleId)
                .Select(x => x.ImageUrl)
                .ToList();

            foreach (var url in urlListOfOriginalSizedImages)
            {
                var tokens = url.Split('/');
                var idWithExt = tokens.Last().ToString();
                var publicId = idWithExt.Split('.').First();

                var deletionParams = new DeletionParams(publicId);

                var deletionResult = cloudinary.DestroyAsync(deletionParams).GetAwaiter().GetResult();
            }
        }

        public string GetResizedImage(Cloudinary cloudinary, string imagePublicId)
        {
            var imageUrl = cloudinary
                               .Api
                               .UrlImgUp
                               .Transform(new Transformation()
                               .Height(480)
                               .Width(720)
                               .Gravity("faces")
                               .Crop("fill"))
                               .BuildUrl(string.Format("{0}.jpg", imagePublicId));

            return imageUrl;
        }
    }
}
