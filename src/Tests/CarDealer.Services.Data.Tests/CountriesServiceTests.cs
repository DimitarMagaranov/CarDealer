namespace CarDealer.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;

    using Xunit;

    public class CountriesServiceTests : BaseServiceTests
    {
        [Fact]
        private async Task CheckIfGetAllAsKeyValuePairsAsyncWorksCorrectly()
        {
            var service = await this.GetCountriesService();

            var result = await service.GetAllAsKeyValuePairsAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        private async Task CheckIfGetCountryIdByNameWorksCorrectly()
        {
            var service = await this.GetCountriesService();

            var result = service.GetCountryIdByName("Country");

            Assert.Equal(1, result);
        }

        private async Task<ICountriesService> GetCountriesService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var repository = new EfRepository<Country>(dbContext);

            var service = new CountriesService(repository);

            return service;
        }
    }
}
