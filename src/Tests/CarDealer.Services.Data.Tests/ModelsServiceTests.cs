namespace CarDealer.Services.Data.Tests
{
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;

    using Xunit;

    public class ModelsServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CheckIfGetByIdMethodWorksCorrectly()
        {
            var service = await this.GetModelsService();

            var result = service.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("Model", result.Name);
        }

        [Fact]
        public async Task CheckIfGetModelNameByCarIdMethodWorksCorrectly()
        {
            var service = await this.GetModelsService();

            var result = service.GetModelNameByCarId(1);

            Assert.Equal("Model", result);
        }

        private async Task<IModelsService> GetModelsService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var carsRepository = new EfDeletableEntityRepository<Car>(dbContext);
            var modelsRepository = new EfRepository<Model>(dbContext);

            var service = new ModelsService(modelsRepository, carsRepository);

            return service;
        }
    }
}
