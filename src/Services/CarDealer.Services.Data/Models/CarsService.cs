namespace CarDealer.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.Cars.CarExtras;
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
        private readonly IRepository<Extra> extrasRepository;
        private readonly IRepository<CarExtra> carExtrasRepository;

        public CarsService(
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IFuelTypesService fuelTypesService,
            IEuroStandartsService euroStandartsService,
            IGearboxesService gearboxesService,
            IColorsService colorsService,
            IRepository<Extra> extrasRepository,
            IRepository<CarExtra> carExtrasRepository)
        {
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.fuelTypesService = fuelTypesService;
            this.euroStandartsService = euroStandartsService;
            this.gearboxesService = gearboxesService;
            this.colorsService = colorsService;
            this.extrasRepository = extrasRepository;
            this.carExtrasRepository = carExtrasRepository;
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

        public IEnumerable<ExtraViewModel> GetAllExtras()
        {
            return this.extrasRepository.AllAsNoTracking()
                .Select(x => new ExtraViewModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                })
                .ToList();
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
