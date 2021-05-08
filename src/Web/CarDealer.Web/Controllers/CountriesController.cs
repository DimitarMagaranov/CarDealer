namespace CarDealer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.Countries;
    using CarDealer.Web.ViewModels.InputModels.Countries;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

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
            int countryId = 0;

            if (this.HttpContext.Session.Keys.Contains("CountryId"))
            {
                countryId = JsonConvert.DeserializeObject<int>(this.HttpContext.Session.GetString("CountryId"));
            }
            else if (this.User.Identity.IsAuthenticated)
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
            else if (input.CallerCotrollerName == null || input.CallerMethodAsString == null)
            {
                this.HttpContext.Session.SetString("CountryId", JsonConvert.SerializeObject(input.CountryId));

                return this.Redirect("/");
            }

            this.HttpContext.Session.SetString("CountryId", JsonConvert.SerializeObject(input.CountryId));

            var countryId = input.CountryId;

            return this.RedirectToAction(input.CallerMethodAsString, input.CallerCotrollerName, new { countryId });
        }
    }
}
