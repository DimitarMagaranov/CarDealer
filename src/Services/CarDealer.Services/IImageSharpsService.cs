namespace CarDealer.Services
{
    using Microsoft.AspNetCore.Http;
    using SixLabors.ImageSharp;

    public interface IImageSharpsService
    {
        Image GetResizedImage(IFormFile image);
    }
}
