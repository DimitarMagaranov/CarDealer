namespace CarDealer.Services
{
    using Microsoft.AspNetCore.Http;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;

    public class ImageSharpsService : IImageSharpsService
    {
        public Image GetResizedImage(IFormFile formFile)
        {
            using var image = Image.Load(formFile.OpenReadStream());
            image.Mutate(x => x.Resize(256, 256));
            return image;
        }
    }
}
