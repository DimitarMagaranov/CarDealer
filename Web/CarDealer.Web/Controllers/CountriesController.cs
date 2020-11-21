namespace CarDealer.Web.Controllers
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Countries;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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
            int countryId;

            if (this.User.Identity.IsAuthenticated)
            {
                var user = await this.userManager.GetUserAsync(this.User);

                if (user.CountryId != null)
                {
                    countryId = (int)user.CountryId;

                    return this.RedirectToAction("Create", "Sales", new { countryId });
                }
            }

            var viewModel = new SelectCountryInputModel();

            viewModel.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCountryForCreateSale(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

                return this.View(input);
            }

            int countryId = input.CountryId;

            return this.RedirectToAction("Create", "Sales", new { countryId });
        }

        public async Task<IActionResult> SelectCountryForGetAllSales()
        {
            int countryId;

            if (this.User.Identity.IsAuthenticated)
            {
                var user = await this.userManager.GetUserAsync(this.User);

                if (user.CountryId != null)
                {
                    countryId = (int)user.CountryId;

                    return this.RedirectToAction("GetAllByCountryId", "Sales", new { countryId });
                }
            }

            var viewModel = new SelectCountryInputModel();

            viewModel.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCountryForGetAllSales(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

                return this.View(input);
            }

            int countryId = input.CountryId;

            return this.RedirectToAction("GetAllByCountryId", "Sales", new { countryId });
        }

        public async Task<IActionResult> SelectAnotherCountryForGetAllSales()
        {
            var viewModel = new SelectCountryInputModel();

            viewModel.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectAnotherCountryForGetAllSales(SelectCountryInputModel input)
        {
            if (input.CountryId == 0)
            {
                input.CountriesItems = await this.countriesService.GetAllAsKeyValuePairsAsync();

                return this.View(input);
            }

            int countryId = input.CountryId;

            return this.RedirectToAction("GetSalesForAnotherCountryById", "Sales", new { countryId });
        }
    }
}
