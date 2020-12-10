namespace CarDealer.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly ICategoriesService categoriesService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IFuelTypesService fuelTypesService;
        private readonly IEuroStandartsService euroStandartsService;
        private readonly IGearboxesService gearboxesService;
        private readonly IColorsService colorsService;

        public CarsService(
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IFuelTypesService fuelTypesService,
            IEuroStandartsService euroStandartsService,
            IGearboxesService gearboxesService,
            IColorsService colorsService)
        {
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.fuelTypesService = fuelTypesService;
            this.euroStandartsService = euroStandartsService;
            this.gearboxesService = gearboxesService;
            this.colorsService = colorsService;
        }

        public Car CreateCar(AddCarInputModel input)
        {
            var carToAdd = new Car
            {
                ModelId = input.ModelId,
                MakeId = input.MakeId,
                CategoryId = input.CategoryId,
                FuelTypeId = input.FuelTypeId,
                EngineSize = input.EngineSize,
                HorsePower = input.HorsePower,
                EuroStandartId = input.EuroStandartId,
                GearboxId = input.GearboxId,
                ColorId = input.ColorId,
                Seats = input.Seats,
                Doors = input.Doors,
                State = input.State,
                Mileage = input.Mileage,
                ManufactureDate = input.ManufactureDate,
            };

            return carToAdd;
        }

        public async Task<AddCarInputModel> GetCarInputModelWithFilledProperties()
        {
            var carViewModel = new AddCarInputModel
            {
                ManufactureDate = DateTime.UtcNow,
                CategoriesItems = await this.categoriesService.GetAllAsSelectListItemsAsync(),
                MakesItems = await this.makesService.GetAllAsSelectListItemsAsync(),
                ModelstItems = await this.modelsService.GetAllAsSelectListItemsAsync(),
                FuelTypeItems = await this.fuelTypesService.GetAllAsSelectListItemsAsync(),
                EuroStandartItems = await this.euroStandartsService.GetAllAsSelectListItemsAsync(),
                GearboxesItems = await this.gearboxesService.GetAllAsSelectListItemsAsync(),
                ColorstItems = await this.colorsService.GetAllAsSelectListItemsAsync(),
            };

            return carViewModel;
        }
    }
}
