namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.Countries;
    using CarDealer.Web.ViewModels.InputModels.Countries;
    using CarDealer.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Authorize]
    public class CountriesController : BaseController
    {
        private readonly ICountriesService countriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public CountriesController(
            ICountriesService countriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.countriesService = countriesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> SelectCountry(string methodName, string controllerName)
        {
            var userCountryName = this.GetUserCountryName();
            var countryId = this.countriesService.GetCountryIdByName(userCountryName);

            if (countryId == 0)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                countryId = user.CountryId;
            }

            this.ViewBag.CallerMethod = methodName;
            this.ViewBag.CallerController = controllerName;

            var viewModel = new SelectCountryViewModel
            {
                CountryId = countryId,
                CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCountry(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

                return this.View(input);
            }

            var countryId = input.CountryId;

            return this.RedirectToAction(input.CallerMethodAsString, input.CallerCotrollerName, new { countryId });
        }

        public string GetUserCountryName()
        {
            UserGeoLocationViewModel viewModel = new UserGeoLocationViewModel();
            GeoHelper geoHelper = new GeoHelper();
            var result = geoHelper.GetGeoInfo().GetAwaiter().GetResult();
            viewModel = JsonConvert.DeserializeObject<UserGeoLocationViewModel>(result);
            var countryName = viewModel.CountryName;

            return countryName;
        }
    }
}
