namespace CarDealer.Web.Controllers
{
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class SalesController : BaseController
    {
        private readonly ISalesService salesService;
        private readonly ICategoriesService categoriesService;
        private readonly IMakesService makesService;
        private readonly IFuelTypesService fuelTypesService;
        private readonly IEuroStandartsService euroStandartsService;
        private readonly IGearboxesService gearboxesService;
        private readonly IColorsService colorsService;
        private readonly IRegionsService regionsService;

        public SalesController(
            ISalesService salesService,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IFuelTypesService fuelTypesService,
            IEuroStandartsService euroStandartsService,
            IGearboxesService gearboxesService,
            IColorsService colorsService,
            IRegionsService regionsService)
        {
            this.salesService = salesService;
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.fuelTypesService = fuelTypesService;
            this.euroStandartsService = euroStandartsService;
            this.gearboxesService = gearboxesService;
            this.colorsService = colorsService;
            this.regionsService = regionsService;
        }

        public IActionResult Create()
        {
            var carViewModel = new AddCarInputModel();

            carViewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            carViewModel.MakesItems = this.makesService.GetAllAsKeyValuePairs();
            carViewModel.FuelTypeItems = this.fuelTypesService.GetAllAsKeyValuePairs();
            carViewModel.EuroStandartItems = this.euroStandartsService.GetAllAsKeyValuePairs();
            carViewModel.GearboxesItems = this.gearboxesService.GetAllAsKeyValuePairs();
            carViewModel.ColorstItems = this.colorsService.GetAllAsKeyValuePairs();

            var viewModel = new AddSaleInputModel();

            viewModel.RegionsItems = this.regionsService.GetAllAsKeyValuePairs();

            viewModel.Car = carViewModel;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSaleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.RegionsItems = this.regionsService.GetAllAsKeyValuePairs();

                var carViewModel = new AddCarInputModel();

                carViewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                carViewModel.MakesItems = this.makesService.GetAllAsKeyValuePairs();
                carViewModel.FuelTypeItems = this.fuelTypesService.GetAllAsKeyValuePairs();
                carViewModel.EuroStandartItems = this.euroStandartsService.GetAllAsKeyValuePairs();
                carViewModel.GearboxesItems = this.gearboxesService.GetAllAsKeyValuePairs();
                carViewModel.ColorstItems = this.colorsService.GetAllAsKeyValuePairs();

                input.Car = carViewModel;

                return this.View(input);
            }

            await this.salesService.CreateSaleAsync(input);

            // TODO: Redirect to car info page

            return this.Redirect("/");
        }
    }
}
