namespace CarDealer.Web.Controllers
{
    using System.Diagnostics;

    using CarDealer.Data.Models;
    using CarDealer.Services;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels;
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

        public IActionResult Index()
        {
            var userCountryName = this.GetUserCountryName();
            var countryId = this.countriesService.GetCountryIdByName(userCountryName);

            var salesViewModel = this.salesService.GetTopSixteenCarsInUsersCountry(countryId);

            this.ViewData["CountryName"] = userCountryName;

            return this.View(salesViewModel);
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

        public string GetUserCountryName()
        {
            UserGeoLocationViewModel viewModel = new UserGeoLocationViewModel();
            var result = this.geoHelperService.GetGeoInfo().GetAwaiter().GetResult();
            viewModel = JsonConvert.DeserializeObject<UserGeoLocationViewModel>(result);
            var countryName = viewModel.CountryName;

            return countryName;
        }
    }
}
