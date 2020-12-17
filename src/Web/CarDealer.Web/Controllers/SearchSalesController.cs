namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;

    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
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

        public async Task<IActionResult> Index(int countryId)
        {
            if (countryId == 0)
            {
                return this.RedirectToAction("SelectCountryForSearchSales", "Countries");
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
                CategoriesItems = await this.categoriesService.GetAllAsSelectListItemsAsync(),
                MakesItems = await this.makesService.GetAllAsSelectListItemsAsync(),
                FuelTypeItems = await this.fuelTypesService.GetAllAsSelectListItemsAsync(),
                EuroStandartItems = await this.euroStandartsService.GetAllAsSelectListItemsAsync(),
                GearboxesItems = await this.gearboxesService.GetAllAsSelectListItemsAsync(),
                ColorstItems = await this.colorsService.GetAllAsSelectListItemsAsync(),
                CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(countryId),
                CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync(),
            };

            return carViewModel;
        }
    }
}
