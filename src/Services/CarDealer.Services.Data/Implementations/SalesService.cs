namespace CarDealer.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Web.ViewModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;

    public class SalesService : ISalesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Sale> salesRepository;
        private readonly ICarsService carsService;
        private readonly ICarExtrasService carExtrasService;
        private readonly IModelsService modelsService;
        private readonly ICitiesService citiesService;
        private readonly IImagesService imagesService;
        private readonly IUsersService usersService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IImageSharpsService imageSharpsService;
        private readonly Cloudinary cloudinary;

        public SalesService(
            ICarsService carsService,
            ICarExtrasService carExtrasService,
            IModelsService modelsService,
            ICitiesService citiesService,
            IImagesService imagesService,
            IUsersService usersService,
            ICloudinaryService cloudinaryService,
            IImageSharpsService imageSharpsService,
            Cloudinary cloudinary,
            IDeletableEntityRepository<Sale> salesRepository)
        {
            this.salesRepository = salesRepository;
            this.carsService = carsService;
            this.carExtrasService = carExtrasService;
            this.modelsService = modelsService;
            this.citiesService = citiesService;
            this.imagesService = imagesService;
            this.usersService = usersService;
            this.cloudinaryService = cloudinaryService;
            this.imageSharpsService = imageSharpsService;
            this.cloudinary = cloudinary;
        }

        public async Task<int> CreateSaleAsync(AddSaleInputModel input, string userId)
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

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var resizedImage = this.imageSharpsService.GetResizedImage(image);

                var imageUrls = await this.cloudinaryService.Upload(this.cloudinary, image);

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                    ImageUrl = imageUrls.Key,
                    ResizedImageUrl = imageUrls.Value,
                };

                saleToAdd.Images.Add(dbImage);
            }

            await this.salesRepository.AddAsync(saleToAdd);
            await this.salesRepository.SaveChangesAsync();

            // await this.carExtrasService.AddExtrasToDbAsync(saleToAdd.CarId, input.Car.CarExtras);
            return saleToAdd.Id;
        }

        public async Task RemoveSaleAsync(int saleId)
        {
            var saleToRemove = this.salesRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == saleId);

            this.salesRepository.Delete(saleToRemove);

            await this.salesRepository.SaveChangesAsync();

            this.cloudinaryService.Delete(this.cloudinary, saleId);
        }

        public async Task<EditSaleInputModel> GetEditSaleInputModel(int id)
        {
            var saleDb = this.salesRepository.All()
                .Include(x => x.Car)
                .FirstOrDefault(x => x.Id == id);

            var carSelectListItems = await this.carsService.GetCarInputModelWithFilledProperties();

            var editSaleInputModel = this.salesRepository.AllAsNoTracking().Where(x => x.Id == id)
                .Select(x => new EditSaleInputModel
                {
                    Id = x.Id,
                    CountryId = x.CountryId,
                    CityId = saleDb.CityId,
                    Description = x.Description,
                    Price = x.Price,
                    DaysValid = x.DaysValid,
                    Car = new EditCarInputModel
                    {
                        MakeId = saleDb.Car.MakeId,
                        ModelId = saleDb.Car.ModelId,
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
                        CategoriesItems = carSelectListItems.CategoriesItems,
                        MakesItems = carSelectListItems.MakesItems,
                        ModelstItems = carSelectListItems.ModelstItems,
                        FuelTypeItems = carSelectListItems.FuelTypeItems,
                        EuroStandartItems = carSelectListItems.EuroStandartItems,
                        GearboxesItems = carSelectListItems.GearboxesItems,
                        ColorstItems = carSelectListItems.ColorstItems,
                    },
                }).FirstOrDefault();

            editSaleInputModel.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(editSaleInputModel.CountryId);

            return editSaleInputModel;
        }

        public IEnumerable<SaleViewModel> GetAllByCountryId(int page, int itemsPerPage, int countryId)
        {
            var data = new List<SaleViewModel>();

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
                .Where(x => x.Id == saleId)
                .Include(x => x.Car)
                .Include(x => x.Car.Make)
                .Include(x => x.Country)
                .Include(x => x.Car.EuroStandart)
                .Include(x => x.Car.Category)
                .Include(x => x.Car.Color)
                .Include(x => x.Car.FuelType)
                .Include(x => x.Car.Gearbox)
                .FirstOrDefault();

            var user = this.usersService.GetUserById(sale.UserId);
            var carModel = this.modelsService.GetById(sale.Car.ModelId);
            var city = this.citiesService.GetById(sale.CityId);
            var images = this.imagesService.GetAllImagesBySaleId(sale.Id);

            var originaImagesUrlList = new List<string>();
            var resizedImagesUrlList = new List<string>();

            foreach (var image in images)
            {
                originaImagesUrlList.Add(image.OriginalImageUrl);
                resizedImagesUrlList.Add(image.ResizedlImageUrl);
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
                OriginalImageUrls = originaImagesUrlList.ToArray(),
                ResizedImageUrls = resizedImagesUrlList.ToArray(),
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

        public async Task UpdateSaleAsync(int id, EditSaleInputModel input)
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

            await this.salesRepository.SaveChangesAsync();
            await this.carsService.UpdateCarAsync(sale.Car.Id, input.Car);
        }

        public async Task DeleteAsync(int id)
        {
            var sale = this.salesRepository.All().FirstOrDefault(x => x.Id == id);

            this.salesRepository.Delete(sale);

            await this.salesRepository.SaveChangesAsync();

            this.cloudinaryService.Delete(this.cloudinary, id);
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

        public async Task<AddSaleInputModel> GetViewModelForCreateSale(int countryId)
        {
            var viewModel = new AddSaleInputModel
            {
                CountryId = countryId,
            };

            viewModel.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(viewModel.CountryId);
            viewModel.Car = await this.carsService.GetCarInputModelWithFilledProperties();

            return viewModel;
        }

        public SalesListViewModel GetSalesListViewModelByCountryId(int id, int itemsPerPage, int countryId)
        {
            var salesListViewModel = new SalesListViewModel();

            salesListViewModel.PageNumber = id;

            salesListViewModel.ItemsPerPage = itemsPerPage;

            salesListViewModel.Sales = this.GetAllByCountryId(id, itemsPerPage, countryId);
            salesListViewModel.SalesCount = this.GetSalesCountByCountryId(countryId);

            return salesListViewModel;
        }

        public SalesListViewModel GetSalesListViewModelByUserId(int id, int itemsPerPage, string userId)
        {
            var viewModel = new SalesListViewModel();

            viewModel.PageNumber = id;

            viewModel.ItemsPerPage = itemsPerPage;

            viewModel.Sales = this.GetAllByUserId(id, itemsPerPage, userId);
            viewModel.SalesCount = this.GetSalesCountByUserId(userId);

            return viewModel;
        }
    }
}
