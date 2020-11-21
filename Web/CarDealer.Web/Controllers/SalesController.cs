﻿namespace CarDealer.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : BaseController
    {
        private static AddSaleInputModel inputModel = new AddSaleInputModel();

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
            var viewModel = new AddSaleInputModel();
            viewModel.CountryId = countryId;

            if (viewModel.CountryId == 0)
            {
                return this.Redirect("/Countries/SelectCountry");
            }

            inputModel.CountryId = countryId;

            viewModel.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(viewModel.CountryId);
            viewModel.Car = await this.GetCarInputModelWithFilledProperties(); 

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSaleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CitiesItems = await this.citiesService.GetAllAsKeyValuePairsAsync(input.CountryId);
                input.Car = await this.GetCarInputModelWithFilledProperties();

                return this.View(input);
            }

            input.CountryId = inputModel.CountryId;

            int cityId = input.CityId;
            int modelId = input.Car.ModelId;
            int saleId = await this.salesService.CreateSaleAsync(input);

            return this.RedirectToAction(nameof(this.SaleInfo), new { saleId });
        }

        //public async Task<IActionResult> GetAllByCountry()
        //{
        //    IEnumerable<SaleViewModel> viewModel = new List<SaleViewModel>();

        //    if (this.User.Identity.IsAuthenticated)
        //    {
        //        var user = await this.userManager.GetUserAsync(this.User);

        //        if (user.CountryId != null)
        //        {
        //            viewModel = this.salesService.GetAllByCountry((int)user.CountryId);

        //            return this.View(viewModel);
        //        }
        //    }

        //    var model = inputModel;

        //    if (model.CountryId == 0)
        //    {
        //        return this.RedirectToAction("/Countries/SelectCountry");
        //    }

        //    int countryId = model.CountryId;

        //    var viewModel = this.salesService.GetAllByCountry(countryId);

        //    return this.View(viewModel);
        //}

        public IActionResult SaleInfo(int saleId)
        {
            var viewModel = this.salesService.GetSaleInfo(saleId);

            return this.View(viewModel);
        }

        public IActionResult AllSalesInfoByCountry(int countryId)
        {
            var viewModel = this.salesService.GetAllByCountry(countryId);

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AdminControlPanel()
        {
            return null;
        }

        public async Task<AddCarInputModel> GetCarInputModelWithFilledProperties()
        {
            var carViewModel = new AddCarInputModel();

            carViewModel.ManufactureDate = DateTime.UtcNow;
            carViewModel.CategoriesItems = await this.categoriesService.GetAllAsKeyValuePairsAsync();
            carViewModel.MakesItems = await this.makesService.GetAllAsKeyValuePairsAsync();
            carViewModel.ModelstItems = await this.modelsService.GetAllAsKeyValuePairsAsync();
            carViewModel.FuelTypeItems = await this.fuelTypesService.GetAllAsKeyValuePairsAsync();
            carViewModel.EuroStandartItems = await this.euroStandartsService.GetAllAsKeyValuePairsAsync();
            carViewModel.GearboxesItems = await this.gearboxesService.GetAllAsKeyValuePairsAsync();
            carViewModel.ColorstItems = await this.colorsService.GetAllAsKeyValuePairsAsync();

            return carViewModel;
        }
    }
}
