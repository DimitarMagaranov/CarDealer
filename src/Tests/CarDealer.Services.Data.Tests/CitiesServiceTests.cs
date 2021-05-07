namespace CarDealer.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;

    using Xunit;

    public class CitiesServiceTests : BaseServiceTests
    {
        [Fact]
        private async Task CheckIfGetCityNameBySaleIdMethodWorksCorrectly()
        {
            var service = await this.GetCitiesService();

            var result = service.GetCityNameBySaleId(1);
            Assert.Equal("City", result);
        }

        [Fact]
        private async Task CheckIfGetAllAsKeyValuePairsAsyncMethodWorksCorrectly()
        {
            var service = await this.GetCitiesService();

            var result = await service.GetAllAsKeyValuePairsAsync(1);

            Assert.Equal(2, result.Count());
        }

        private async Task<ICitiesService> GetCitiesService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var citiesRepository = new EfRepository<City>(dbContext);
            var salesRepository = new EfDeletableEntityRepository<Sale>(dbContext);

            var service = new CitiesService(citiesRepository, salesRepository);

            return service;
        }
    }
}
