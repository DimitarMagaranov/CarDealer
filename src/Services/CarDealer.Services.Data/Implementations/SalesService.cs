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
    using CarDealer.Services.Mapping;
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
        private readonly ICloudinaryService cloudinaryService;
        private readonly IImageSharpsService imageSharpsService;
        private readonly Cloudinary cloudinary;

        public SalesService(
            ICarsService carsService,
            ICarExtrasService carExtrasService,
            IModelsService modelsService,
            ICitiesService citiesService,
            IImagesService imagesService,
            ICloudinaryService cloudinaryService,
            IImageSharpsService imageSharpsService,
            IDeletableEntityRepository<Sale> salesRepository,
            Cloudinary cloudinary)
        {
            this.salesRepository = salesRepository;
            this.carsService = carsService;
            this.carExtrasService = carExtrasService;
            this.modelsService = modelsService;
            this.citiesService = citiesService;
            this.imagesService = imagesService;
            this.cloudinaryService = cloudinaryService;
            this.imageSharpsService = imageSharpsService;
            this.cloudinary = cloudinary;
        }

        public async Task<int> CreateSaleAsync(AddSaleViewModel input, string userId)
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

            await this.carExtrasService.AddExtrasToDbAsync(saleToAdd.CarId, input.CarExtras);
            return saleToAdd.Id;
        }

        public async Task<EditSaleViewModel> GetEditSaleViewModel(int id)
        {
            var editSaleViewModel = this.salesRepository.AllAsNoTracking().Where(x => x.Id == id).To<EditSaleViewModel>().FirstOrDefault();

            var carSelectListItems = await this.carsService.GetCarInputModelWithFilledListItems();

            editSaleViewModel.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(editSaleViewModel.CountryId);
            editSaleViewModel.Car.CategoriesItems = carSelectListItems.CategoriesItems;
            editSaleViewModel.Car.MakesItems = carSelectListItems.MakesItems;
            editSaleViewModel.Car.ModelstItems = carSelectListItems.ModelstItems;
            editSaleViewModel.Car.FuelTypeItems = carSelectListItems.FuelTypeItems;
            editSaleViewModel.Car.EuroStandartItems = carSelectListItems.EuroStandartItems;
            editSaleViewModel.Car.GearboxesItems = carSelectListItems.GearboxesItems;
            editSaleViewModel.Car.ColorstItems = carSelectListItems.ColorstItems;

            return editSaleViewModel;
        }

        public IEnumerable<SaleViewModel> GetAllByCountryId(int page, int itemsPerPage, int countryId)
        {
            var data = new List<SaleViewModel>();

            var sales = this.salesRepository.AllAsNoTracking()
                .Where(x => x.CountryId == countryId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
            
            sales.ForEach(x => data.Add(this.GetSaleInfo(x.Id)));

            return data;
        }

        public IEnumerable<SaleViewModel> GetUserDashboardSalesByUserId(string userId)
        {
            var data = new List<SaleViewModel>();

            this.salesRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .ToList()
                .ForEach(x => data.Add(this.GetSaleInfo(x.Id)));

            return data;
        }

        public IEnumerable<SaleViewModel> GetAllBySearchForm(SearchListInputModel input)
        {
            var sales = this.salesRepository.All()
                .Where(x => x.CountryId == input.CountryId && x.Images.FirstOrDefault() != null)
                .Include(x => x.Car)
                .ToList();

            if (input.CityId != null)
            {
                sales = sales.Where(x => x.CityId == input.CityId).ToList();
            }

            if (input.CategoryId != null)
            {
                sales = sales.Where(x => x.Car.CategoryId == input.CategoryId).ToList();
            }

            if (input.State != null)
            {
                sales = sales.Where(x => x.Car.State == input.State).ToList();
            }

            if (input.FuelTypeId != null)
            {
                sales = sales.Where(x => x.Car.FuelTypeId == input.FuelTypeId).ToList();
            }

            if (input.GearboxId != null)
            {
                sales = sales.Where(x => x.Car.GearboxId == input.GearboxId).ToList();
            }

            if (input.Doors != null)
            {
                sales = sales.Where(x => x.Car.Doors == input.Doors).ToList();
            }

            if (input.Seats != null)
            {
                sales = sales.Where(x => x.Car.Seats == input.Seats).ToList();
            }

            if (input.MakeId != null)
            {
                sales = sales.Where(x => x.Car.MakeId == (int)input.MakeId).ToList();

                if (input.ModelId != null)
                {
                    sales = sales.Where(x => x.Car.MakeId == (int)input.MakeId && x.Car.ModelId == input.ModelId).ToList();
                }
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

            if (input.MilleageFrom != null)
            {
                sales = sales.Where(x => x.Car.Mileage >= input.MilleageFrom).ToList();
            }

            if (input.MilleageTo != null)
            {
                sales = sales.Where(x => x.Car.Mileage <= input.MilleageTo).ToList();
            }

            if (input.EngineSizeFrom != null)
            {
                sales = sales.Where(x => x.Car.EngineSize >= input.EngineSizeFrom).ToList();
            }

            if (input.EngineSizeTo != null)
            {
                sales = sales.Where(x => x.Car.EngineSize <= input.EngineSizeTo).ToList();
            }

            if (input.PowerFrom != null)
            {
                sales = sales.Where(x => x.Car.HorsePower >= input.PowerFrom).ToList();
            }

            if (input.PowerTo != null)
            {
                sales = sales.Where(x => x.Car.HorsePower <= input.PowerTo).ToList();
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
            var images = this.imagesService.GetAllImagesBySaleId(saleId);

            var originaImagesUrlList = new List<string>();
            var resizedImagesUrlList = new List<string>();

            foreach (var image in images)
            {
                originaImagesUrlList.Add(image.ImageUrl);
                resizedImagesUrlList.Add(image.ResizedImageUrl);
            }

            var saleInfo = this.salesRepository.All()
                .Where(x => x.Id == saleId)
                .To<SaleViewModel>()
                .FirstOrDefault();

            if (saleInfo == null)
            {
                return null;
            }

            saleInfo.CityName = this.citiesService.GetCityNameBySaleId(saleId);
            saleInfo.OriginalImageUrls = originaImagesUrlList.ToArray();
            saleInfo.ResizedImageUrls = resizedImagesUrlList.ToArray();
            saleInfo.Car.ModelName = this.modelsService.GetModelNameByCarId(saleInfo.CarId);
            saleInfo.Car.Extras = this.carExtrasService.GetExtrasByCarId(saleInfo.CarId);

            return saleInfo;
        }

        public int GetSalesCountByCountryId(int countryId)
        {
            return this.salesRepository.AllAsNoTracking().Where(x => x.CountryId == countryId).Count();
        }

        public async Task<SaleViewModel> UpdateSaleAsync(int id, EditSaleInputModel input)
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

            return this.GetSingleSaleInfo(id);
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

        public IEnumerable<SaleViewModel> GetTopSixteenCarsInUsersCountry(int id)
        {
            var data = new List<SaleViewModel>();

            this.salesRepository.All()
                .Where(x => x.CountryId == id)
                .OrderByDescending(x => x.CreatedOn)
                .Take(16)
                .ToList()
                .ForEach(x => data.Add(this.GetSaleInfo(x.Id)));

            return data;
        }

        public async Task<AddSaleViewModel> GetViewModelForCreateSale(int countryId)
        {
            var viewModel = new AddSaleViewModel
            {
                CountryId = countryId,
            };

            viewModel.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(viewModel.CountryId);
            viewModel.Car = await this.carsService.GetCarInputModelWithFilledListItems();

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

        public async Task<IEnumerable<SaleViewModel>> GetSalesListViewModelByUserId(string id)
        {
            var salesListViewModel = new List<SaleViewModel>();

            await this.salesRepository.All().Where(x => x.UserId == id).ForEachAsync(x => salesListViewModel.Add(this.GetSaleInfo(x.Id)));

            return salesListViewModel;
        }
    }
}
