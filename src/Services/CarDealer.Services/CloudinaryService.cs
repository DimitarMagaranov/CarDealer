namespace CarDealer.Services
{
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

        public async Task<string> Upload(Cloudinary cloudinary, IFormFile file)
        {
            string imageUrl;

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

                imageUrl = result.Uri.AbsoluteUri;
            }

            return imageUrl;
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
    }
}
