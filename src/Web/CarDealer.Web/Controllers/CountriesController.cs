namespace CarDealer.Web.Controllers
{
    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Countries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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

        [Authorize]
        public async Task<IActionResult> SelectCountryForCreateSale()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            int countryId = user.CountryId;

            var viewModel = new SelectCountryInputModel { CountryId = countryId, CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync() };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SelectCountryForCreateSale(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

                return this.View(input);
            }

            var countryId = input.CountryId;

            return this.RedirectToAction("Create", "Sales", new { countryId });
        }

        [Authorize]
        public async Task<IActionResult> SelectCountryForGetAllSales()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            int countryId = user.CountryId;

            var viewModel = new SelectCountryInputModel { CountryId = countryId, CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync() };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SelectCountryForGetAllSales(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

                return this.View(input);
            }

            var countryId = input.CountryId;

            return this.RedirectToAction("All", "Sales", new { countryId });
        }
    }
}
