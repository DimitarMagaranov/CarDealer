namespace CarDealer.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Data.SqlClient;

    [Authorize]
    public class SearchSalesController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
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
        private readonly UserManager<ApplicationUser> userManager;

        public SearchSalesController(
            IWebHostEnvironment webHostEnvironment,
            ISalesService salesService,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IFuelTypesService fuelTypesService,
            IEuroStandartsService euroStandartsService,
            IGearboxesService gearboxesService,
            IColorsService colorsService,
            ICountriesService countriessService,
            ICitiesService citiesService,
            UserManager<ApplicationUser> userManager)
        {
            this.webHostEnvironment = webHostEnvironment;
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
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int countryId)
        {
            if (countryId == 0)
            {
                return this.RedirectToAction("SelectCountryForSearchSales", "Countries");
            }

            var viewModel = await this.GetSearchListInputModelWithFilledProperties(countryId);

            viewModel.CountryId = countryId;

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List(SearchListInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var salesListViewModel = new SalesListViewModel();

            salesListViewModel.Sales = this.salesService.GetAllBySearchForm(input);

            return this.View(salesListViewModel);
        }

        public async Task<SearchListInputModel> GetSearchListInputModelWithFilledProperties(int countryId)
        {
            var carViewModel = new SearchListInputModel();

            carViewModel.CategoriesItems = await this.categoriesService.GetAllAsSelectListItemsAsync();
            carViewModel.MakesItems = await this.makesService.GetAllAsSelectListItemsAsync();
            carViewModel.ModelstItems = await this.modelsService.GetAllAsSelectListItemsAsync();
            carViewModel.FuelTypeItems = await this.fuelTypesService.GetAllAsSelectListItemsAsync();
            carViewModel.EuroStandartItems = await this.euroStandartsService.GetAllAsSelectListItemsAsync();
            carViewModel.GearboxesItems = await this.gearboxesService.GetAllAsSelectListItemsAsync();
            carViewModel.ColorstItems = await this.colorsService.GetAllAsSelectListItemsAsync();
            carViewModel.CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(countryId);
            carViewModel.CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync();

            return carViewModel;
        }
    }
}
