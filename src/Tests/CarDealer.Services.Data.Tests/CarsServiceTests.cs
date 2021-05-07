namespace CarDealer.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    using Xunit;

    public class CarsServiceTests : BaseServiceTests
    {
        [Fact]
        private async Task CheckIfCreateCarMethodWorksCorrectly()
        {
            var service = await this.GetCarsService();

            var carInputModel = this.GetAddCarInputModel();

            var carToAdd = service.CreateCar(carInputModel);

            Assert.Equal(carInputModel.ModelId, carToAdd.ModelId);
            Assert.Equal(carInputModel.MakeId, carToAdd.MakeId);
            Assert.Equal(carInputModel.CategoryId, carToAdd.CategoryId);
            Assert.Equal(carInputModel.FuelTypeId, carToAdd.FuelTypeId);
            Assert.Equal(carInputModel.EngineSize, carToAdd.EngineSize);
            Assert.Equal(carInputModel.HorsePower, carToAdd.HorsePower);
            Assert.Equal(carInputModel.EuroStandartId, carToAdd.EuroStandartId);
            Assert.Equal(carInputModel.GearboxId, carToAdd.GearboxId);
            Assert.Equal(carInputModel.ColorId, carToAdd.ColorId);
            Assert.Equal(carInputModel.Seats, carToAdd.Seats);
            Assert.Equal(carInputModel.Doors, carToAdd.Doors);
            Assert.Equal(carInputModel.State, carToAdd.State);
            Assert.Equal(carInputModel.Mileage, carToAdd.Mileage);
            Assert.Equal(carInputModel.ManufactureDate, carToAdd.ManufactureDate);
        }

        [Fact]
        private async Task CheckIfUpdateCarAsyncWorksCorrectly()
        {
            var service = await this.GetCarsService();

            var inputModel = this.GetEditCarInputModel();

            var result = await service.UpdateCarAsync(1, inputModel);

            Assert.Equal(1, result.Id);
            Assert.Equal(inputModel.ModelId, result.ModelId);
            Assert.Equal(inputModel.MakeId, result.MakeId);
            Assert.Equal(inputModel.CategoryId, result.CategoryId);
            Assert.Equal(inputModel.FuelTypeId, result.FuelTypeId);
            Assert.Equal(inputModel.EngineSize, result.EngineSize);
            Assert.Equal(inputModel.HorsePower, result.HorsePower);
            Assert.Equal(inputModel.EuroStandartId, result.EuroStandartId);
            Assert.Equal(inputModel.GearboxId, result.GearboxId);
            Assert.Equal(inputModel.ColorId, result.ColorId);
            Assert.Equal(inputModel.Mileage, result.Mileage);
            Assert.Equal(inputModel.ManufactureDate, result.ManufactureDate);
        }

        [Fact]
        private async Task CheckIfGetCarInputModelWithFilledListItemsMethodWorksCorrectly()
        {
            var service = await this.GetCarsService();

            var result = await service.GetCarInputModelWithFilledListItems();

            Assert.Equal(2, result.CategoriesItems.Count());
            Assert.Equal(2, result.MakesItems.Count());
            Assert.Equal(2, result.FuelTypeItems.Count());
            Assert.Equal(2, result.EuroStandartItems.Count());
            Assert.Equal(2, result.GearboxesItems.Count());
            Assert.Equal(2, result.ColorstItems.Count());
        }

        private async Task<ICarsService> GetCarsService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            IDeletableEntityRepository<Car> carsRepository = new EfDeletableEntityRepository<Car>(dbContext);

            return new CarsService(
                carsRepository,
                this.GetCategoriesService(),
                this.GetMakesService(),
                this.GetFuelTypesService(),
                this.GetEuroStandartsService(),
                this.GetGearBoxesService(),
                this.GetColorsService());
        }

        private ICategoriesService GetCategoriesService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            IRepository<Category> repository = new EfRepository<Category>(dbContext);

            ICategoriesService service = new CategoriesService(repository);
            return service;
        }

        private IMakesService GetMakesService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            IRepository<Make> repository = new EfRepository<Make>(dbContext);

            IMakesService service = new MakesService(repository);
            return service;
        }

        private IFuelTypesService GetFuelTypesService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            IRepository<FuelType> repository = new EfRepository<FuelType>(dbContext);

            IFuelTypesService service = new FuelTypesService(repository);
            return service;
        }

        private IEuroStandartsService GetEuroStandartsService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            IRepository<EuroStandart> repository = new EfRepository<EuroStandart>(dbContext);

            IEuroStandartsService service = new EuroStandartsService(repository);
            return service;
        }

        private IGearboxesService GetGearBoxesService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            IRepository<Gearbox> repository = new EfRepository<Gearbox>(dbContext);

            IGearboxesService service = new GearboxesService(repository);
            return service;
        }

        private IColorsService GetColorsService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            IRepository<Color> repository = new EfRepository<Color>(dbContext);

            IColorsService service = new ColorsService(repository);
            return service;
        }

        private EditCarInputModel GetEditCarInputModel()
        {
            return new EditCarInputModel
            {
                ModelId = 2,
                MakeId = 2,
                CategoryId = 2,
                FuelTypeId = 2,
                EngineSize = 2,
                HorsePower = 2,
                EuroStandartId = 2,
                GearboxId = 2,
                ColorId = 2,
                Seats = (Seats)2,
                Doors = (Doors)2,
                State = (State)2,
                Mileage = 2,
                ManufactureDate = DateTime.Now,
            };
        }

        private AddCarInputModel GetAddCarInputModel()
        {
            return new AddCarInputModel
            {
                ModelId = 1,
                MakeId = 1,
                CategoryId = 1,
                FuelTypeId = 1,
                EngineSize = 1,
                HorsePower = 1,
                EuroStandartId = 1,
                GearboxId = 1,
                ColorId = 1,
                Seats = (Seats)1,
                Doors = (Doors)1,
                State = (State)1,
                Mileage = 1,
                ManufactureDate = DateTime.Now,
            };
        }
    }
}
