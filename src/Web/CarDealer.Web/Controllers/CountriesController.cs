namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Countries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> SelectCountryForCreateSale()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            int countryId = user.CountryId;

            var viewModel = new SelectCountryInputModel { CountryId = countryId, CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync() };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCountryForCreateSale(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync();

                return this.View(input);
            }

            var countryId = input.CountryId;

            return this.RedirectToAction("Create", "Sales", new { countryId });
        }

        public async Task<IActionResult> SelectCountryForGetAllSales()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            int countryId = user.CountryId;

            var viewModel = new SelectCountryInputModel { CountryId = countryId, CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync() };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCountryForGetAllSales(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync();

                return this.View(input);
            }

            var countryId = input.CountryId;

            return this.RedirectToAction("All", "Sales", new { countryId });
        }

        public async Task<IActionResult> SelectCountryForSearchSales()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            int countryId = user.CountryId;

            var viewModel = new SelectCountryInputModel { CountryId = countryId, CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync() };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCountryForSearchSales(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsSelectListItemsAsync();

                return this.View(input);
            }

            var countryId = input.CountryId;

            return this.RedirectToAction("Index", "SearchSales", new { countryId });
        }
    }
}
