namespace CarDealer.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Common;
    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;

    using GoogleReCaptcha.V3.Interface;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

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
        private readonly ICaptchaValidator captchaValidator;
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
            UserManager<ApplicationUser> userManager,
            ICaptchaValidator captchaValidator)
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
            this.captchaValidator = captchaValidator;
        }

        [Authorize]
        public async Task<IActionResult> Create(int countryId)
        {
            if (countryId == 0)
            {
                var methodName = nameof(this.Create).ToString();
                var controllerName = nameof(SalesController).Replace(GlobalConstants.ControllerAsString, string.Empty);
                var nameOfCountriesController = nameof(CountriesController).Replace(GlobalConstants.ControllerAsString, string.Empty);
                var nameOfSelectCountryActionInCountriesController = nameof(CountriesController.SelectCountry);

                return this.RedirectToAction(nameOfSelectCountryActionInCountriesController, nameOfCountriesController, new { methodName, controllerName });
            }

            var viewModel = await this.salesService.GetViewModelForCreateSale(countryId);

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AddSaleViewModel input, string captcha)
        {
            if (!await this.captchaValidator.IsCaptchaPassedAsync(captcha))
            {
                this.ModelState.AddModelError(GlobalConstants.ReCaptchaName, GlobalConstants.ReCaptchaErrorMessage);
            }

            if (!this.ModelState.IsValid)
            {
                input.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(input.CountryId);
                input.Car = await this.carsService.GetCarInputModelWithFilledListItems();

                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            int id = 0;

            try
            {
                id = await this.salesService.CreateSaleAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(input.CountryId);
                input.Car = await this.carsService.GetCarInputModelWithFilledListItems();
                return this.View(input);
            }

            this.TempData["Message"] = GlobalConstants.SuccessfullyAddedSaleMessage;

            return this.RedirectToAction(nameof(this.SaleInfo), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await this.salesService.GetEditSaleViewModel(id);

            return this.View(viewModel);
        }

        [Authorize]
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

        public async Task<IActionResult> All(int id = 1)
        {
            int countryId;

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
                var methodName = nameof(this.All).ToString();
                var controllerName = nameof(SalesController).Replace(GlobalConstants.ControllerAsString, string.Empty);
                var nameOfCountriesController = nameof(CountriesController).Replace(GlobalConstants.ControllerAsString, string.Empty);
                var nameOfSelectCountryActionInCountriesController = nameof(CountriesController.SelectCountry);

                return this.RedirectToAction(nameOfSelectCountryActionInCountriesController, nameOfCountriesController, new { methodName, controllerName });
            }

            const int ItemsPerPage = 12;

            var viewModel = await this.salesService.GetSalesListViewModelByCountryId(id, ItemsPerPage, countryId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllByUserId(string id)
        {
            var viewModel = await this.salesService.GetSalesListViewModelByUserId(id);

            return this.View(viewModel);
        }

        public async Task<IActionResult> SaleInfo(int id)
        {
            var viewModel = await this.salesService.GetSingleSaleInfo(id);

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> DeleteSale(int id)
        {
            await this.salesService.DeleteAsync(id);

            var nameOfUsersController = nameof(DashboardController).Replace(GlobalConstants.ControllerAsString, string.Empty);
            var nameOfAllActionInUsersController = nameof(DashboardController.Index);

            return this.RedirectToAction(nameOfAllActionInUsersController, nameOfUsersController);
        }
    }
}
