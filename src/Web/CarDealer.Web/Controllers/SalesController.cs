namespace CarDealer.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SalesController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICarsService carsService;
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

        public SalesController(
            IWebHostEnvironment webHostEnvironment,
            ICarsService carsService,
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
            this.carsService = carsService;
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

        public async Task<IActionResult> Create(int countryId)
        {
            if (countryId == 0)
            {
                return this.RedirectToAction("SelectCountryForCreateSale", "Countries");
            }

            var viewModel = await this.salesService.GetViewModelForCreateSale(countryId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSaleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(input.CountryId);
                input.Car = await this.carsService.GetCarInputModelWithFilledProperties();

                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            int id = 0;

            try
            {
                id = await this.salesService.CreateSaleAsync(input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(input.CountryId);
                input.Car = await this.carsService.GetCarInputModelWithFilledProperties();
                return this.View(input);
            }

            this.TempData["Message"] = "Sale added successfully.";

            return this.RedirectToAction(nameof(this.SaleInfo), new { id });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await this.salesService.GetEditSaleInputModel(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditSaleInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            input.CountryId = user.CountryId;

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.salesService.UpdateSaleAsync(id, input);

            return this.RedirectToAction(nameof(this.SaleInfo), new { id });
        }

        public async Task<IActionResult> All(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            const int ItemsPerPage = 12;

            if (id == 0)
            {
                id++;
            }

            var viewModel = this.salesService.GetSalesListViewModelByCountryId(id, ItemsPerPage, user.CountryId);

            return this.View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult SaleInfo(int id)
        {
            var viewModel = this.salesService.GetSingleSaleInfo(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSale(int id)
        {
            await this.salesService.DeleteAsync(id);

            return this.RedirectToAction("All", "Users");
        }
    }
}
