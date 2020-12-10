namespace CarDealer.Services.Data
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
    using CarDealer.Web.ViewModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.EntityFrameworkCore;

    public class SalesService : ISalesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Sale> salesRepository;
        private readonly ICarsService carsService;
        private readonly IRepository<City> citiesRepository;
        private readonly IRepository<Model> modelsRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public SalesService(
            ICarsService carsService,
            IDeletableEntityRepository<Sale> salesRepository,
            IRepository<Model> modelsRepository,
            IRepository<City> citiesRepository,
            IDeletableEntityRepository<Car> carsRepository,
            IDeletableEntityRepository<Image> imagesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.salesRepository = salesRepository;
            this.carsService = carsService;
            this.modelsRepository = modelsRepository;
            this.carsRepository = carsRepository;
            this.imagesRepository = imagesRepository;
            this.usersRepository = usersRepository;
            this.citiesRepository = citiesRepository;
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
                UserId = userId,
                OpensSaleCounter = 0,
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
            var saleDb = this.salesRepository.All()
                .Include(x => x.Car)
                .FirstOrDefault(x => x.Id == id);
            var carModel = this.modelsRepository.AllAsNoTracking().First(x => x.Id == saleDb.Car.ModelId);
            var city = this.citiesRepository.AllAsNoTracking().First(x => x.Id == saleDb.CityId);

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
                        MakeId = saleDb.Car.MakeId,
                        ModelId = carModel.Id,
                        State = saleDb.Car.State,
                        EngineSize = saleDb.Car.EngineSize,
                        HorsePower = (int)saleDb.Car.HorsePower,
                        EuroStandartId = saleDb.Car.EuroStandartId,
                        ManufactureDate = saleDb.Car.ManufactureDate,
                        CategoryId = saleDb.Car.CategoryId,
                        ColorId = saleDb.Car.ColorId,
                        FuelTypeId = saleDb.Car.FuelTypeId,
                        GearboxId = saleDb.Car.GearboxId,
                        Seats = saleDb.Car.Seats,
                        Doors = saleDb.Car.Doors,
                        Mileage = saleDb.Car.Mileage,
                    },
                }).FirstOrDefault();

            return sale;
        }

        public IEnumerable<SaleViewModel> GetAllByCountryId(int page, int itemsPerPage, int countryId)
        {
            var data = new List<SaleViewModel>();

            itemsPerPage = 12;

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

        public IEnumerable<SaleViewModel> GetAllBySearchForm(SearchListInputModel input)
        {
            var sales = this.salesRepository.All()
                .Where(x => x.CountryId == input.CountryId && x.Images.FirstOrDefault() != null)
                .Include(x => x.Car)
                .ToList();

            if (input.MakeId != null)
            {
                sales = sales.Where(x => x.Car.MakeId == (int)input.MakeId).ToList();

                if (input.ModelId != null)
                {
                    sales = sales.Where(x => x.Car.MakeId == (int)input.MakeId && x.Car.ModelId == input.ModelId).ToList();
                }
            }

            if (input.State != null)
            {
                sales = sales.Where(x => x.Car.State == input.State).ToList();
            }

            if (input.ManufacturerYearFrom != null)
            {
                sales = sales.Where(x => x.Car.ManufactureDate.Year >= input.ManufacturerYearFrom).ToList();
            }

            if (input.ManufacturerYearTo != null)
            {
                sales = sales.Where(x => x.Car.ManufactureDate.Year <= input.ManufacturerYearTo).ToList();
            }

            if (input.PriceFrom != null)
            {
                sales = sales.Where(x => x.Price >= input.PriceFrom).ToList();
            }

            if (input.PriceTo != null)
            {
                sales = sales.Where(x => x.Price <= input.PriceTo).ToList();
            }

            if (input.FuelTypeId != null)
            {
                sales = sales.Where(x => x.Car.FuelTypeId == input.FuelTypeId).ToList();
            }

            if (input.GearboxId != null)
            {
                sales = sales.Where(x => x.Car.GearboxId == input.GearboxId).ToList();
            }

            if (input.EngineSizeFrom != null)
            {
                sales = sales.Where(x => x.Car.EngineSize >= input.EngineSizeFrom).ToList();
            }

            if (input.EngineSizeTo != null)
            {
                sales = sales.Where(x => x.Car.EngineSize <= input.EngineSizeTo).ToList();
            }

            if (input.MilleageFrom != null)
            {
                sales = sales.Where(x => x.Car.Mileage >= input.MilleageFrom).ToList();
            }

            if (input.MilleageTo != null)
            {
                sales = sales.Where(x => x.Car.Mileage <= input.MilleageTo).ToList();
            }

            //if (input.SortCommand != null)
            //{
            //    switch (input.SortCommand)
            //    {
            //        case "Price (Low - High)":
            //            sales = sales.OrderBy(x => x.Price);
            //            break;
            //        case "Manufacture date":
            //            sales = sales.OrderBy(x => x.Car.ManufactureDate);
            //            break;
            //        case "Miliage":
            //            sales = sales.OrderBy(x => x.Car.Mileage);
            //            break;
            //        case "Newest sales":
            //            sales = sales.OrderByDescending(x => x.CreatedOn);
            //            break;
            //        default:
            //            break;
            //    }
            //}

            var salesToShow = new List<SaleViewModel>();

            foreach (var sale in sales)
            {
                salesToShow.Add(this.GetSaleInfo(sale.Id));
            }

            return salesToShow;
        }

        public SaleViewModel GetSingleSaleInfo(int saleId)
        {
            this.IncreaseOpensSaleCounter(saleId).GetAwaiter().GetResult();

            return this.GetSaleInfo(saleId);
        }

        public SaleViewModel GetSaleInfo(int saleId)
        {
            var sale = this.salesRepository.All()
                .Include(x => x.Car)
                .Include(x => x.Car.Make)
                .Include(x => x.Country)
                .Include(x => x.Car.EuroStandart)
                .Include(x => x.Car.Category)
                .Include(x => x.Car.Color)
                .Include(x => x.Car.FuelType)
                .Include(x => x.Car.Gearbox)
                .FirstOrDefault(x => x.Id == saleId);

            var user = this.usersRepository.AllAsNoTracking().First(x => x.Id == sale.UserId);
            var carModel = this.modelsRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == sale.Car.ModelId);
            var city = this.citiesRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == sale.CityId);
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
                Name = $"{sale.Car.Make.Name} {carModel.Name} {sale.Car.EngineSize}",
                CountryName = sale.Country.Name,
                CityName = city.Name,
                CreatedOn = sale.CreatedOn,
                Description = sale.Description,
                Price = sale.Price,
                ImageUrls = imagesUrlList.ToArray(),
                UserName = user.UserName,
                UserPhoneNumber = user.PhoneNumber,
                UserEmailAddress = user.Email,
                OpensSaleCount = sale.OpensSaleCounter,
                Car = new CarViewModel
                {
                    Make = sale.Car.Make.Name,
                    Model = carModel.Name,
                    State = sale.Car.State.ToString(),
                    EngineSize = sale.Car.EngineSize,
                    HorsePower = (int)sale.Car.HorsePower,
                    EuroStandart = sale.Car.EuroStandart.Name,
                    ManufactureDate = sale.Car.ManufactureDate,
                    CategoryName = sale.Car.Category.Name,
                    Color = sale.Car.Color.Name,
                    FuelType = sale.Car.FuelType.Name,
                    Gearbox = sale.Car.Gearbox.Name,
                    Seats = sale.Car.Seats.ToString(),
                    Doors = sale.Car.Doors.ToString(),
                    Mileage = sale.Car.Mileage,
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
            var sale = this.salesRepository.All()
                .Include(x => x.Car)
                .FirstOrDefault(x => x.Id == id);

            sale.CountryId = input.CountryId;
            sale.CityId = input.CityId;
            sale.CountryId = input.CountryId;
            sale.DaysValid = input.DaysValid;
            sale.Description = input.Description;
            sale.ModifiedOn = DateTime.UtcNow;
            sale.Price = input.Price;

            sale.Car.CategoryId = input.Car.CategoryId;
            sale.Car.ColorId = input.Car.ColorId;
            sale.Car.Doors = input.Car.Doors;
            sale.Car.EngineSize = input.Car.EngineSize;
            sale.Car.EuroStandartId = input.Car.EuroStandartId;
            sale.Car.FuelTypeId = input.Car.FuelTypeId;
            sale.Car.GearboxId = input.Car.GearboxId;
            sale.Car.HorsePower = input.Car.HorsePower;
            sale.Car.MakeId = input.Car.MakeId;
            sale.Car.ManufactureDate = input.Car.ManufactureDate;
            sale.Car.Mileage = input.Car.Mileage;
            sale.Car.ModelId = input.Car.ModelId;
            sale.Car.ModifiedOn = DateTime.UtcNow;
            sale.Car.Seats = input.Car.Seats;
            sale.Car.State = input.Car.State;

            await this.salesRepository.SaveChangesAsync();
            await this.carsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sale = this.salesRepository.All().FirstOrDefault(x => x.Id == id);

            this.salesRepository.Delete(sale);

            await this.salesRepository.SaveChangesAsync();
        }

        public async Task IncreaseOpensSaleCounter(int id)
        {
            var sale = this.salesRepository.All().FirstOrDefault(x => x.Id == id);

            sale.OpensSaleCounter += 1;

            await this.salesRepository.SaveChangesAsync();
        }

        public IEnumerable<SaleViewModel> GetTopNineCarsInUsersCountry(int id)
        {
            var data = new List<SaleViewModel>();

            var sales = this.salesRepository.All()
                .Where(x => x.CountryId == id)
                .OrderByDescending(x => x.CreatedOn)
                .Take(9)
                .ToList();

            foreach (var sale in sales)
            {
                data.Add(this.GetSaleInfo(sale.Id));
            }

            return data;
        }

        public IEnumerable<SaleViewModel> GetTopNineCarsFromEnywhere()
        {
            var data = new List<SaleViewModel>();

            var sales = this.salesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(9)
                .ToList();

            foreach (var sale in sales)
            {
                data.Add(this.GetSaleInfo(sale.Id));
            }

            return data;
        }
    }
}
