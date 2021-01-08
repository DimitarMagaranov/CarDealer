namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<KeyValuePair<string, string>> Upload(Cloudinary cloudinary, IFormFile file);

        void Delete(Cloudinary cloudinary, int saleId);
    }
}
