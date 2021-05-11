namespace CarDealer.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Data.Repositories;
    using CarDealer.Services.Data.Implementations;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;

    using CloudinaryDotNet;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.Extensions.Configuration;

    using Xunit;

    public class SalesServiceTests : BaseServiceTests
    {
        [Fact]
        private async Task CheckIfCreateSaleAsyncWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.CreateSaleAsync(this.GetAddSaleInputModel(), "1");

            Assert.Equal(2, result);
        }

        [Fact]
        private async Task CheckIfGetEditSaleViewModelMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.GetEditSaleViewModel(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        private async Task CheckIfGetAllByCountryIdMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.GetAllByCountryId(1, 1, 1);
            var resultCount = result.Count();

            Assert.NotNull(result);
            Assert.Equal(1, resultCount);
            Assert.Equal(1, result.FirstOrDefault().Id = 1);
        }

        [Fact]
        private async Task CheckIfGetSaleInfoMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.GetSaleInfo(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        private async Task CheckIfGetUserDashboardSalesByUserIdMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.GetUserDashboardSalesByUserId("1");
            var resultCount = result.Count();

            Assert.NotNull(result);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        private async Task CheckIfGetAllBySearchFormMethodWorksCorrectly()
        {
            var searchListModel = this.GetSearchListInputModel();

            var service = await this.GetSalesService();

            var result = await service .GetAllBySearchForm(searchListModel);
            var resultCount = result.Count();

            Assert.Equal(1, resultCount);
            Assert.Equal(1, result.FirstOrDefault().Id);
        }

        [Fact]
        private async Task CheckIfGetSingleSaleInfoMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = service.GetSingleSaleInfo(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        private async Task CheckIfGetSalesCountByCountryIdMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.GetSalesCountByCountryId(1);

            Assert.Equal(1, result);
        }

        [Fact]
        private async Task CheckIfUpdateSaleAsyncMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();
            var editSaleInputModel = this.GetEditSaleInputModel();

            var result = await service.UpdateSaleAsync(1, editSaleInputModel);

            Assert.NotNull(result);
            Assert.Equal("UpdatedDescription", result.Description);
        }

        [Fact]
        private async Task CheckIfDeleteAsyncWorksCorrectly()
        {
            var service = await this.GetSalesService();

            await service.DeleteAsync(1);

            Assert.Null(await service.GetSaleInfo(1));
        }

        [Fact]
        private async Task CheckIfIncreaseOpensSaleCounterMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            await service.IncreaseOpensSaleCounter(1);

            var sale = await service.GetSingleSaleInfo(1);

            var opensSaleCount = sale.OpensSaleCounter;

            Assert.Equal(3, opensSaleCount);
        }

        [Fact]
        private async Task CheckIfGetTopSixteenCarsInUsersCountryWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service .GetTopSixteenCarsInUsersCountry(1);

            Assert.True(result.Count() <= 16);
            Assert.True(result.Count() >= 1);
        }

        [Fact]
        private async Task CheckIfGetViewModelForCreateSaleMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.GetViewModelForCreateSale(1);

            Assert.NotNull(result);
        }

        [Fact]
        private async Task CheckIfGetSalesListViewModelByCountryIdMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service .GetSalesListViewModelByCountryId(1, 1, 1);
            var resultCount = result.Sales.Count();

            Assert.NotNull(result);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        private async Task CheckIfGetSalesListViewModelByUserIdMethodWorksCorrectly()
        {
            var service = await this.GetSalesService();

            var result = await service.GetSalesListViewModelByUserId("1");
            var resultCount = result.Count();

            Assert.NotNull(result);
            Assert.Equal(1, resultCount);
            Assert.Equal("1", result.First().UserId);
        }

        private async Task<ISalesService> GetSalesService()
        {
            var dbContext = await this.GetUseInMemoryDbContext();

            var repository = new EfDeletableEntityRepository<Sale>(dbContext);

            return new SalesService(
                this.GetCarsService(),
                this.GetCarExtrasService(),
                this.GetModelsService(),
                this.GetCitiesService(),
                this.GetImagesService(),
                this.GetCloudinaryService(),
                new ImageSharpsService(),
                repository,
                this.GetCloudinary());
        }

        private IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }

        private ICarsService GetCarsService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var repository = new EfDeletableEntityRepository<Car>(dbContext);

            var service = new CarsService(
                repository,
                this.GetCategoriesService(),
                this.GetMakesService(),
                this.GetFuelTypesService(),
                this.GetEuroStandartsService(),
                this.GetGearBoxesService(),
                this.GetColorsService());

            return service;
        }

        private ICarExtrasService GetCarExtrasService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var repository = new EfRepository<CarExtra>(dbContext);

            var service = new CarExtrasService(repository, this.GetExtrasService());

            return service;
        }

        private IExtrasService GetExtrasService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var repository = new EfRepository<Extra>(dbContext);

            var service = new ExtrasService(repository);

            return service;
        }

        private IModelsService GetModelsService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var modelsRepository = new EfRepository<Model>(dbContext);
            var carsRepository = new EfDeletableEntityRepository<Car>(dbContext);

            var service = new ModelsService(modelsRepository, carsRepository);

            return service;
        }

        private ICitiesService GetCitiesService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var citiesRepository = new EfRepository<City>(dbContext);
            var salesRepository = new EfDeletableEntityRepository<Sale>(dbContext);

            var service = new CitiesService(citiesRepository, salesRepository);

            return service;
        }

        private IImagesService GetImagesService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var repository = new EfDeletableEntityRepository<Image>(dbContext);

            var service = new ImagesService(repository);

            return service;
        }

        private IUsersService GetUsersService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var repository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);

            var service = new UsersService(repository);

            return service;
        }

        private ICloudinaryService GetCloudinaryService()
        {
            var dbContext = this.GetUseInMemoryDbContext().GetAwaiter().GetResult();

            var service = new CloudinaryService(dbContext);

            return service;
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

        private Cloudinary GetCloudinary()
        {
            var configuration = this.GetConfiguration();

            Account account = new Account(
                              configuration["Cloudinary:AppName"],
                              configuration["Cloudinary:AppKey"],
                              configuration["Cloudinary:AppSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);

            return cloudinary;
        }

        private IFormFile GetIFormFile()
        {
            var stream = File.OpenRead(@"C:\Users\Dimitar\Desktop\no-image-found-360x250.png");

            var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(@"C:\Users\Dimitar\Desktop\no-image-found-360x250.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };

            return file;
        }

        private AddSaleViewModel GetAddSaleInputModel()
        {
            return new AddSaleViewModel
            {
                Car = new AddCarInputModel
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
                },
                CityId = 1,
                CountryId = 1,
                DaysValid = 20,
                Description = "Description",
                MakeId = 1,
                ModelId = 1,
                Price = 1,
                UserId = "1",
                Images = new List<IFormFile> { this.GetIFormFile() },
            };
        }

        private EditSaleInputModel GetEditSaleInputModel()
        {
            return new EditSaleInputModel
            {
                Description = "UpdatedDescription",
                CountryId = 1,
                CityId = 1,
                DaysValid = 10,
                Price = 10,
                Car = new EditCarInputModel
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
                },
            };
        }

        private SearchListInputModel GetSearchListInputModel()
        {
            return new SearchListInputModel
            {
                Seats = (Seats)1,
                State = (State)1,
                EngineSizeFrom = 1,
                EngineSizeTo = 1,
                CategoryId = 1,
                CityId = 1,
                CountryId = 1,
                Doors = (Doors)1,
                FuelTypeId = 1,
                GearboxId = 1,
                MakeId = 1,
                ManufacturerYearFrom = DateTime.Now.Year,
                ManufacturerYearTo = DateTime.Now.Year,
                MilleageFrom = 1,
                MilleageTo = 1,
                ModelId = 1,
                PowerFrom = 1,
                PowerTo = 1,
                PriceFrom = 1,
                PriceTo = 1,
            };
        }
    }
}
