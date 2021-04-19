﻿namespace CarDealer.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels;
    using CarDealer.Web.ViewModels.Countries;
    using CarDealer.Web.ViewModels.Users;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    public class HomeController : BaseController
    {
        private readonly ISalesService salesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> logger;
        private readonly ICountriesService countriesService;
        private readonly IGeoHelperService geoHelperService;

        public HomeController(
            ISalesService salesService,
            UserManager<ApplicationUser> userManager,
            ILogger<HomeController> logger,
            ICountriesService countriesService,
            IGeoHelperService geoHelperService)
        {
            this.salesService = salesService;
            this.userManager = userManager;
            this.logger = logger;
            this.countriesService = countriesService;
            this.geoHelperService = geoHelperService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new SelectCountryViewModel
            {
                CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync(),
            };

            if (this.User.Identity.IsAuthenticated)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                viewModel.CountryId = user.CountryId;
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SelectCountryViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new SelectCountryViewModel
                {
                    CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync(),
                };

                return this.View(viewModel);
            }

            var countryId = inputModel.CountryId;
            return this.RedirectToAction(nameof(this.IndexCars), new { countryId });
        }

        public async Task<IActionResult> IndexCars(int countryId)
        {
            if (countryId == 0)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                countryId = user.CountryId;

                var salesViewModel = this.salesService.GetTopSixteenCarsInUsersCountry(countryId);
                return this.View(salesViewModel);
            }

            var viewModel = this.salesService.GetTopSixteenCarsInUsersCountry(countryId);
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult TermsAndConditions()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
