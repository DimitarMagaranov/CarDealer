namespace CarDealer.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : BaseController
    {
        private static AddSaleInputModel inputModel = new AddSaleInputModel();

        private readonly ISalesService salesService;
        private readonly ICategoriesService categoriesService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IFuelTypesService fuelTypesService;
        private readonly IEuroStandartsService euroStandartsService;
        private readonly IGearboxesService gearboxesService;
        private readonly IColorsService colorsService;
        private readonly ICountriesService countriesService;
        private readonly ICitiesService citiesService;

        public SalesController(
            ISalesService salesService,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IFuelTypesService fuelTypesService,
            IEuroStandartsService euroStandartsService,
            IGearboxesService gearboxesService,
            IColorsService colorsService,
            ICountriesService countriessService,
            ICitiesService citiesService)
        {
            this.salesService = salesService;
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.fuelTypesService = fuelTypesService;
            this.euroStandartsService = euroStandartsService;
            this.gearboxesService = gearboxesService;
            this.colorsService = colorsService;
            this.countriesService = countriessService;
            this.citiesService = citiesService;
        }

        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            var viewModel = inputModel;

            if (viewModel.CountryId == 0)
            {
                return this.RedirectToAction(nameof(this.SelectCountry));
            }

            viewModel.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(viewModel.CountryId);
            viewModel.Car = await this.GetCarInputModelWithFilledPropertiesAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync(AddSaleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(input.CountryId);
                input.Car = await this.GetCarInputModelWithFilledPropertiesAsync();

                return this.View(input);
            }

            input.CountryId = inputModel.CountryId;

            int cityId = input.CityId;
            int modelId = input.Car.ModelId;
            int saleId = await this.salesService.CreateSaleAsync(input);

            // TODO: Redirect to car info page

            return this.RedirectToAction(nameof(this.SaleInfo), new { saleId, modelId, cityId });
        }

        //public IActionResult GetAll()
        //{
        //    var viewModel = inputModel;

        //    if (viewModel.CountryId == 0)
        //    {
        //        return this.RedirectToAction(nameof(this.SelectCountry));
        //    }

        //    viewModel.CitiesItems = this.citiesService.GetAllAsKeyValuePairs(viewModel.CountryId);
        //}

        [ActionName("SelectCountry")]
        public async Task<IActionResult> SelectCountryAsync()
        {
            var viewModel = inputModel;

            viewModel.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        [ActionName("SelectCountry")]
        public async Task<IActionResult> SelectCountryAsync(AddSaleInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

                return this.View(input);
            }

            inputModel = input;

            return this.Redirect("/Sales/Create");
        }

        public IActionResult SaleInfo(int saleId, int modelId, int cityId)
        {
            var viewModel = this.salesService.GetSaleInfo(saleId, modelId, cityId);

            return this.View(viewModel);
        }

        public async Task<AddCarInputModel> GetCarInputModelWithFilledPropertiesAsync()
        {
            var carViewModel = new AddCarInputModel();

            carViewModel.ManufactureDate = DateTime.UtcNow;
            carViewModel.CategoriesItems = await this.categoriesService.GetAllAsKeyValuePairsAsync();
            carViewModel.MakesItems = await this.makesService.GetAllAsKeyValuePairsAsync();
            carViewModel.ModelstItems = await this.modelsService.GetAllAsKeyValuePairsAsync();
            carViewModel.FuelTypeItems = await this.fuelTypesService.GetAllAsKeyValuePairsAsync();
            carViewModel.EuroStandartItems = await this.euroStandartsService.GetAllAsKeyValuePairsAsync();
            carViewModel.GearboxesItems = await this.gearboxesService.GetAllAsKeyValuePairsAsync();
            carViewModel.ColorstItems = await this.colorsService.GetAllAsKeyValuePairsAsync();

            return carViewModel;
        }
    }
}
