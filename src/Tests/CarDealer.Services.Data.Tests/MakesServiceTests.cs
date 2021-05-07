namespace CarDealer.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;

    using Xunit;

    public class MakesServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CheckIfGetMakeWithModelsAsyncWorksCorrectly()
        {
            var service = await this.GetMakesService();

            var result = await service.GetMakeWithModelsAsync(1);
            var model = result.FirstOrDefault();

            Assert.NotNull(model);
            Assert.NotNull(model.Models.FirstOrDefault());
            Assert.Equal("Make", model.Name);
            Assert.Equal("Model", model.Models.FirstOrDefault().Name);
        }

        [Fact]
        public async Task CheckIfGetAllAsKeyValuePairsAsyncWorksCorrectly()
        {
            var service = await this.GetMakesService();

            var result = await service.GetAllAsKeyValuePairsAsync();

            Assert.Equal(2, result.Count());
        }

        private async Task<IMakesService> GetMakesService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var repository = new EfRepository<Make>(dbContext);

            var service = new MakesService(repository);

            return service;
        }
    }
}
