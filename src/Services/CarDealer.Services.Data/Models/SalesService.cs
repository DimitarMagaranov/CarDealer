namespace CarDealer.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data;
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Services.Data.Dtos;
    using CarDealer.Web.ViewModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class SalesService : ISalesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly ApplicationDbContext db;
        private readonly ICarsService carsService;
        private readonly IDeletableEntityRepository<Sale> salesRepository;
        private readonly IRepository<Country> countriesRepository;
        private readonly IRepository<City> citiesRepository;
        private readonly IRepository<Model> modelsRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IRepository<Make> makesRepository;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Color> colorsRepository;
        private readonly IRepository<FuelType> fuelTypesRepository;
        private readonly IRepository<Gearbox> gearboxesRepository;
        private readonly IRepository<EuroStandart> euroStandartsRepository;
        private readonly IRepository<MetaData> metaDatasRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public SalesService(
            ApplicationDbContext db,
            ICarsService carsService,
            IDeletableEntityRepository<Sale> salesRepository,
            IRepository<Country> countriesRepository,
            IRepository<City> citiesRepository,
            IRepository<Model> modelsRepository,
            IDeletableEntityRepository<Car> carsRepository,
            IRepository<Make> makesRepository,
            IRepository<Category> categoriesRepository,
            IRepository<Color> colorsRepository,
            IRepository<FuelType> fuelTypesRepository,
            IRepository<Gearbox> gearboxesRepository,
            IRepository<EuroStandart> euroStandartsRepository,
            IRepository<MetaData> metaDatasRepository,
            IDeletableEntityRepository<Image> imagesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.db = db;
            this.carsService = carsService;
            this.salesRepository = salesRepository;
            this.countriesRepository = countriesRepository;
            this.citiesRepository = citiesRepository;
            this.modelsRepository = modelsRepository;
            this.carsRepository = carsRepository;
            this.makesRepository = makesRepository;
            this.categoriesRepository = categoriesRepository;
            this.colorsRepository = colorsRepository;
            this.fuelTypesRepository = fuelTypesRepository;
            this.gearboxesRepository = gearboxesRepository;
            this.euroStandartsRepository = euroStandartsRepository;
            this.metaDatasRepository = metaDatasRepository;
            this.imagesRepository = imagesRepository;
            this.usersRepository = usersRepository;
        }

        public async Task<int> CreateSaleAsync(AddSaleInputModel input, string userId, string imagePath)
        {
            var saleToAdd = new Sale
            {
                CityId = input.CityId,
                DaysValid = input.DaysValid,
                Price = input.Price,
                CountryId = input.CountryId,
                Description = input.Description,
                Car = this.carsService.CreateCar(input.Car),
                MetaData = new MetaData { SaleCityId = input.CityId, CarModelId = input.Car.ModelId },
                UserId = userId,
            };

            Directory.CreateDirectory($"{imagePath}/sales/");

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                saleToAdd.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/sales/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.salesRepository.AddAsync(saleToAdd);
            await this.salesRepository.SaveChangesAsync();

            return saleToAdd.Id;
        }

        public async Task RemoveSaleAsync(int saleId)
        {
            var saleToRemove = this.salesRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == saleId);

            this.salesRepository.Delete(saleToRemove);

            await this.salesRepository.SaveChangesAsync();
        }

        public EditSaleInputModel GetEditSaleInputModel(int id)
        {
            var saleDb = this.salesRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            var carDb = this.carsRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == saleDb.CarId);
            var metaData = this.metaDatasRepository.AllAsNoTracking().First(x => x.Id == saleDb.MetaDataId);
            var carModel = this.modelsRepository.AllAsNoTracking().First(x => x.Id == metaData.CarModelId);
            var city = this.citiesRepository.AllAsNoTracking().First(x => x.Id == metaData.SaleCityId);

            var sale = this.salesRepository.AllAsNoTracking().Where(x => x.Id == id)
                .Select(x => new EditSaleInputModel
                {
                    Id = x.Id,
                    CountryId = x.CountryId,
                    CityId = city.Id,
                    Description = x.Description,
                    Price = x.Price,
                    DaysValid = x.DaysValid,
                    Car = new EditCarInputModel
                    {
                        MakeId = carDb.MakeId,
                        ModelId = carModel.Id,
                        State = carDb.State,
                        EngineSize = carDb.EngineSize,
                        HorsePower = (int)carDb.HorsePower,
                        EuroStandartId = carDb.EuroStandartId,
                        ManufactureDate = carDb.ManufactureDate,
                        CategoryId = carDb.CategoryId,
                        ColorId = carDb.ColorId,
                        FuelTypeId = carDb.FuelTypeId,
                        GearboxId = carDb.GearboxId,
                        Seats = carDb.Seats,
                        Doors = carDb.Doors,
                        Mileage = carDb.Mileage,
                    },
                }).FirstOrDefault();

            return sale;
        }

        public IEnumerable<SaleViewModel> GetAllByCountryId(int page, int itemsPerPage, int countryId)
        {
            var data = new List<SaleViewModel>();

            itemsPerPage = 2;

            var sales = this.salesRepository.All()
                .Where(x => x.CountryId == countryId)
                .ToList();

            sales = sales
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            foreach (var sale in sales)
            {
                data.Add(this.GetSaleInfo(sale.Id));
            }

            return data;
        }

        public IEnumerable<SaleViewModel> GetAllByUserId(int page, int itemsPerPage, string userId)
        {
            var data = new List<SaleViewModel>();

            itemsPerPage = 2;

            var sales = this.salesRepository.All()
                .Where(x => x.UserId == userId)
                .ToList();

            sales = sales
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            foreach (var sale in sales)
            {
                data.Add(this.GetSaleInfo(sale.Id));
            }

            return data;
        }

        public IEnumerable<SaleViewModel> GetAllBySearchForm(SearchSaleFormInputModel input)
        {
            var sales = this.salesRepository.All().Where(x => x.Car.Category.Name == input.Category);

            if (input.Make != null)
            {
                sales = sales.Where(x => x.Car.Make.Name == input.Make);

                if (input.Model != null)
                {
                    sales = sales.Where(x => x.Car.Make.Name == input.Make && x.Car.Make.Models.All(m => m.Name == input.Model));
                }
            }

            if (input.State != null)
            {
                sales = sales.Where(x => x.Car.State == input.State);
            }

            if (input.ManufactureYearFrom != null)
            {
                sales = sales.Where(x => x.Car.ManufactureDate.Year >= input.ManufactureYearFrom);
            }

            if (input.ManufactureYearTo != null)
            {
                sales = sales.Where(x => x.Car.ManufactureDate.Year <= input.ManufactureYearTo);
            }

            if (input.PriceFrom != null)
            {
                sales = sales.Where(x => x.Price >= input.PriceFrom);
            }

            if (input.PriceTo != null)
            {
                sales = sales.Where(x => x.Price <= input.PriceTo);
            }

            if (input.FuelType != null)
            {
                sales = sales.Where(x => x.Car.FuelType.Name == input.FuelType);
            }

            if (input.Gearbox != null)
            {
                sales = sales.Where(x => x.Car.Gearbox.Name == input.Gearbox);
            }

            if (input.EngineSizeFrom != null)
            {
                sales = sales.Where(x => x.Car.EngineSize >= input.EngineSizeFrom);
            }

            if (input.EngineSizeTo != null)
            {
                sales = sales.Where(x => x.Car.EngineSize <= input.EngineSizeTo);
            }

            if (input.MileageTo != null)
            {
                sales = sales.Where(x => x.Car.Mileage <= input.MileageTo);
            }

            if (input.Color != null)
            {
                sales = sales.Where(x => x.Car.Color.Name == input.Color);
            }

            if (input.EuroStandart != null)
            {
                sales = sales.Where(x => x.Car.EuroStandart.Name == input.EuroStandart);
            }

            if (input.Country != null)
            {
                sales = sales.Where(x => x.Country.Name == input.Country);
            }

            if (input.SortCommand != null)
            {
                switch (input.SortCommand)
                {
                    case "Price (Low - High)":
                        sales = sales.OrderBy(x => x.Price);
                        break;
                    case "Manufacture date":
                        sales = sales.OrderBy(x => x.Car.ManufactureDate);
                        break;
                    case "Miliage":
                        sales = sales.OrderBy(x => x.Car.Mileage);
                        break;
                    case "Newest sales":
                        sales = sales.OrderByDescending(x => x.CreatedOn);
                        break;
                    default:
                        break;
                }
            }

            var salesToShow = new List<SaleViewModel>();

            foreach (var sale in sales)
            {
                salesToShow.Add(this.GetSaleInfo(sale.Id));
            }

            return salesToShow;
        }

        public SaleViewModel GetSaleInfo(int saleId)
        {
            var sale = this.salesRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == saleId);
            var user = this.usersRepository.AllAsNoTracking().First(x => x.Id == sale.UserId);
            var car = this.carsRepository.AllAsNoTracking().First(x => x.Id == sale.CarId);
            var carMake = this.makesRepository.AllAsNoTracking().First(x => x.Id == car.MakeId);
            var metaData = this.metaDatasRepository.AllAsNoTracking().First(x => x.Id == sale.MetaDataId);
            var carModel = this.modelsRepository.AllAsNoTracking().First(x => x.Id == metaData.CarModelId);
            var country = this.countriesRepository.AllAsNoTracking().First(x => x.Id == sale.CountryId);
            var city = this.citiesRepository.AllAsNoTracking().First(x => x.Id == metaData.SaleCityId);
            var category = this.categoriesRepository.AllAsNoTracking().First(x => x.Id == car.CategoryId);
            var color = this.colorsRepository.AllAsNoTracking().First(x => x.Id == car.ColorId);
            var fuelType = this.fuelTypesRepository.AllAsNoTracking().First(x => x.Id == car.FuelTypeId);
            var gearbox = this.gearboxesRepository.AllAsNoTracking().First(x => x.Id == car.GearboxId);
            var euroStandart = this.euroStandartsRepository.AllAsNoTracking().First(x => x.Id == car.EuroStandartId);
            var images = this.imagesRepository.AllAsNoTracking().Where(x => x.SaleId == saleId);

            var imagesUrlList = new List<string>();

            foreach (var image in images)
            {
                var imageUrl = "/images/sales/" + image.Id + "." + image.Extension;
                imagesUrlList.Add(imageUrl);
            }

            var saleInfo = new SaleViewModel
            {
                Id = sale.Id,
                Name = $"{carMake.Name} {carModel.Name} {car.EngineSize}",
                CountryName = country.Name,
                CityName = city.Name,
                CreatedOn = sale.CreatedOn,
                Description = sale.Description,
                Price = sale.Price,
                ImageUrls = imagesUrlList.ToArray(),
                UserName = user.UserName,
                UserPhoneNumber = user.PhoneNumber,
                UserEmailAddress = user.Email,
                Car = new CarViewModel
                {
                    Make = carMake.Name,
                    Model = carModel.Name,
                    State = car.State.ToString(),
                    EngineSize = car.EngineSize,
                    HorsePower = (int)car.HorsePower,
                    EuroStandart = euroStandart.Name,
                    ManufactureDate = car.ManufactureDate,
                    CategoryName = category.Name,
                    Color = color.Name,
                    FuelType = fuelType.Name,
                    Gearbox = gearbox.Name,
                    Seats = car.Seats.ToString(),
                    Doors = car.Doors.ToString(),
                    Mileage = car.Mileage,
                },
            };

            return saleInfo;
        }

        public int GetSalesCountByCountryId(int countryId)
        {
            return this.salesRepository.All().Where(x => x.CountryId == countryId).Count();
        }

        public int GetSalesCountByUserId(string userId)
        {
            return this.salesRepository.All().Where(x => x.UserId == userId).Count();
        }

        public async Task UpdateAsync(int id, EditSaleInputModel input)
        {
            var sale = this.salesRepository.All().FirstOrDefault(x => x.Id == id);
            var car = this.carsRepository.All().FirstOrDefault(x => x.Id == sale.CarId);
            var metaData = this.metaDatasRepository.All().FirstOrDefault(x => x.Id == sale.MetaDataId);

            sale.CountryId = input.CountryId;
            sale.CityId = input.CityId;
            sale.CountryId = input.CountryId;
            sale.DaysValid = input.DaysValid;
            sale.Description = input.Description;
            sale.ModifiedOn = DateTime.UtcNow;
            sale.Price = input.Price;

            metaData.SaleCityId = input.CityId;
            metaData.CarModelId = input.Car.ModelId;

            car.CategoryId = input.Car.CategoryId;
            car.ColorId = input.Car.ColorId;
            car.Doors = input.Car.Doors;
            car.EngineSize = input.Car.EngineSize;
            car.EuroStandartId = input.Car.EuroStandartId;
            car.FuelTypeId = input.Car.FuelTypeId;
            car.GearboxId = input.Car.GearboxId;
            car.HorsePower = input.Car.HorsePower;
            car.MakeId = input.Car.MakeId;
            car.ManufactureDate = input.Car.ManufactureDate;
            car.Mileage = input.Car.Mileage;
            car.ModelId = input.Car.ModelId;
            car.ModifiedOn = DateTime.UtcNow;
            car.Seats = input.Car.Seats;
            car.State = input.Car.State;

            await this.salesRepository.SaveChangesAsync();
            await this.carsRepository.SaveChangesAsync();
            await this.metaDatasRepository.SaveChangesAsync();
        }
    }
}
