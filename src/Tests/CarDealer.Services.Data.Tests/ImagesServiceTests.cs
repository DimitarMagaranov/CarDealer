using CarDealer.Data.Common.Repositories;
using CarDealer.Data.Models.SaleModels;
using CarDealer.Data.Repositories;
using CarDealer.Services.Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarDealer.Services.Data.Tests
{
    public class ImagesServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CheckIfGetAllImagesBySaleIdMethodWorksCorectly()
        {
            var service = await this.GetImagesService();

            var result = await service.GetAllImagesBySaleId(1);

            var imagesCount = result.Count();

            Assert.Equal(1, imagesCount);
            Assert.Equal("https://res.cloudinary.com/dlxqza3bo/image/upload/v1620225901/mloed3ykpjwuavrivfbv.png", result.ToList()[0].ImageUrl);
        }

        [Fact]
        public async Task CheckIfGetImageViewModelByIdWorksCorrectly()
        {
            var service = await this.GetImagesService();

            var result = await service.GetImageViewModelById("1");

            Assert.Equal("https://res.cloudinary.com/dlxqza3bo/image/upload/v1620225901/mloed3ykpjwuavrivfbv.png", result.ImageUrl);
        }

        private async Task<IImagesService> GetImagesService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var repository = new EfDeletableEntityRepository<Image>(dbContext);

            var service = new ImagesService(repository);

            return service;
        }
    }
}
