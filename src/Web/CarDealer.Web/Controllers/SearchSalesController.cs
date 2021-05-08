namespace CarDealer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Common;
    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    public class SearchSalesController : BaseController
    {
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
            if (this.HttpContext.Session.Keys.Contains("CountryId"))
            {
                countryId = JsonConvert.DeserializeObject<int>(this.HttpContext.Session.GetString("CountryId"));
            }
            else if (this.User.Identity.IsAuthenticated)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                countryId = user.CountryId;
            }
            else
            {
                var methodName = nameof(this.Index).ToString();
                var controllerName = nameof(SearchSalesController).Replace(GlobalConstants.ControllerAsString, string.Empty);
                var nameOfCountriesController = nameof(CountriesController).Replace(GlobalConstants.ControllerAsString, string.Empty);
                var nameOfSelectCountryActionInCountriesController = nameof(CountriesController.SelectCountry);

                return this.RedirectToAction(nameOfSelectCountryActionInCountriesController, nameOfCountriesController, new { methodName, controllerName });
            }

            this.TempData["CountryId"] = countryId;

            var viewModel = await this.GetSearchListInputModelWithFilledProperties(countryId);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var salesListViewModel = new SalesListViewModel();

            salesListViewModel.Sales = this.salesService.GetAllBySearchForm(input);

            return this.View(salesListViewModel);
        }

        public async Task<SearchListInputModel> GetSearchListInputModelWithFilledProperties(int countryId)
        {
            var carViewModel = new SearchListInputModel
            {
                CountryId = countryId,
                CategoriesItems = await this.categoriesService.GetAllAsKeyValuePairsAsync(),
                MakesItems = await this.makesService.GetAllAsKeyValuePairsAsync(),
                FuelTypeItems = await this.fuelTypesService.GetAllAsKeyValuePairsAsync(),
                EuroStandartItems = await this.euroStandartsService.GetAllAsKeyValuePairsAsync(),
                GearboxesItems = await this.gearboxesService.GetAllAsKeyValuePairsAsync(),
                ColorstItems = await this.colorsService.GetAllAsKeyValuePairsAsync(),
                CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(countryId),
                CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync(),
            };

            return carViewModel;
        }
    }
}
