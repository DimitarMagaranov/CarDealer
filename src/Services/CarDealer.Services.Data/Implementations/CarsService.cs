namespace CarDealer.Services.Data.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly ICategoriesService categoriesService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IFuelTypesService fuelTypesService;
        private readonly IEuroStandartsService euroStandartsService;
        private readonly IGearboxesService gearboxesService;
        private readonly IColorsService colorsService;

        public CarsService(
            IDeletableEntityRepository<Car> carsRepository,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IFuelTypesService fuelTypesService,
            IEuroStandartsService euroStandartsService,
            IGearboxesService gearboxesService,
            IColorsService colorsService)
        {
            this.carsRepository = carsRepository;
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
                CategoryId = (int)input.CategoryId,
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
                CategoriesItems = await this.categoriesService.GetAllAsKeyValuePairsAsync(),
                MakesItems = await this.makesService.GetAllAsKeyValuePairsAsync(),
                FuelTypeItems = await this.fuelTypesService.GetAllAsKeyValuePairsAsync(),
                EuroStandartItems = await this.euroStandartsService.GetAllAsKeyValuePairsAsync(),
                GearboxesItems = await this.gearboxesService.GetAllAsKeyValuePairsAsync(),
                ColorstItems = await this.colorsService.GetAllAsKeyValuePairsAsync(),
            };

            return carViewModel;
        }

        public async Task UpdateCarAsync(int id, EditCarInputModel input)
        {
            var carDb = this.carsRepository.All().First(x => x.Id == id);

            carDb.CategoryId = input.CategoryId;
            carDb.ColorId = input.ColorId;
            carDb.Doors = input.Doors;
            carDb.EngineSize = input.EngineSize;
            carDb.EuroStandartId = input.EuroStandartId;
            carDb.FuelTypeId = input.FuelTypeId;
            carDb.GearboxId = input.GearboxId;
            carDb.HorsePower = input.HorsePower;
            carDb.MakeId = input.MakeId;
            carDb.ManufactureDate = input.ManufactureDate;
            carDb.Mileage = input.Mileage;
            carDb.ModelId = input.ModelId;
            carDb.ModifiedOn = DateTime.UtcNow;
            carDb.Seats = input.Seats;
            carDb.State = input.State;

            await this.carsRepository.SaveChangesAsync();
        }
    }
}
