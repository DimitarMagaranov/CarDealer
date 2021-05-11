namespace CarDealer.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;

    using Moq;
    using Xunit;

    public class CarExtrasServiceTests : BaseServiceTests
    {
        [Fact]
        private async Task CheckIfGetExtrasByIdReturnsCorrectExtras()
        {
            var extrasService = await this.GetExtrasService();
            var carExtrasService = await this.GetCarExtrasService();

            var expectedExtras = new List<string>
            {
                "Extra1",
                "Extra2",
            };

            var result = await carExtrasService.GetExtrasByCarId(1);

            Assert.Equal(expectedExtras[0], result.ToList()[0]);
            Assert.Equal(expectedExtras[1], result.ToList()[1]);
        }

        [Fact]
        private async Task CheckIfAddExtrasToDbAsyncMethodWorksCorrectlyWIthPassedCarExtras()
        {
            var carExtrasDb = new List<CarExtra>();

            var carExtrasRepository = new Mock<IRepository<CarExtra>>();
            carExtrasRepository.Setup(x => x.AddAsync(It.IsAny<CarExtra>()))
                .Callback((CarExtra x) => carExtrasDb.Add(x));

            var extrasRepository = new Mock<IRepository<Extra>>();

            IExtrasService extrasService = new ExtrasService(extrasRepository.Object);
            ICarExtrasService carExtrasService = new CarExtrasService(carExtrasRepository.Object, extrasService);

            await carExtrasService.AddExtrasToDbAsync(1, new List<int> { 1, 2 });

            Assert.Equal(1, carExtrasDb[0].CarId);
            Assert.Equal(1, carExtrasDb[0].ExtraId);
            Assert.Equal(1, carExtrasDb[1].CarId);
            Assert.Equal(2, carExtrasDb[1].ExtraId);
        }

        [Fact]
        private async Task CheckIfAddExtrasToDbAsyncMethodWorksCorrectlyWIthNoPassedCarExtras()
        {
            var carExtrasDb = new List<CarExtra>();

            var carExtrasRepository = new Mock<IRepository<CarExtra>>();
            carExtrasRepository.Setup(x => x.AddAsync(It.IsAny<CarExtra>()))
                .Callback((CarExtra x) => carExtrasDb.Add(x));

            var extrasRepository = new Mock<IRepository<Extra>>();

            IExtrasService extrasService = new ExtrasService(extrasRepository.Object);
            ICarExtrasService carExtrasService = new CarExtrasService(carExtrasRepository.Object, extrasService);

            await carExtrasService.AddExtrasToDbAsync(1, null);

            var carExtrasCount = carExtrasDb.Count();

            Assert.Equal(0, carExtrasCount);
        }

        private async Task<ICarExtrasService> GetCarExtrasService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var repository = new EfRepository<CarExtra>(dbContext);

            var extrasService = await this.GetExtrasService();

            var service = new CarExtrasService(repository, extrasService);

            return service;
        }

        private async Task<IExtrasService> GetExtrasService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var repository = new EfRepository<Extra>(dbContext);

            var extrasService = new ExtrasService(repository);

            return extrasService;
        }
    }
}
