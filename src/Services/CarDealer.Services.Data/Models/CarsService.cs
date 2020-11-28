namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Services.Data.Dtos;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carsRepository;

        public CarsService(IDeletableEntityRepository<Car> carsRepository)
        {
            this.carsRepository = carsRepository;
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
                EuroStandartId = input.EuroStandartId,
                GearboxId = input.GearboxId,
                ColorId = input.ColorId,
                Doors = input.Doors,
                State = input.State,
                Mileage = input.Mileage,
                ManufactureDate = input.ManufactureDate,
            };

            return carToAdd;
        }

        public async Task RemoveCarByIdAsync(int carId)
        {
            var carToDelete = this.carsRepository.All().FirstOrDefault(x => x.Id == carId);

            this.carsRepository.Delete(carToDelete);

            await this.carsRepository.SaveChangesAsync();
        }

        public CarDto GetCarById(int id)
        {
            var car = this.carsRepository.All().FirstOrDefault(x => x.Id == id);

            var data = new CarDto
            {
                Id = car.Id,
                Make = car.Make.Name,
                Category = car.Category.Name,
                State = car.State.ToString(),
                EngineSize = car.EngineSize,
                EuroStandart = car.EuroStandart.Name,
                Color = car.Color.Name,
                Doors = car.Doors.ToString(),
                ManufactureDate = car.ManufactureDate,
                FuelType = car.FuelType.Name,
                Gearbox = car.Gearbox.Name,
                Mileage = car.Mileage,
            };

            return data;
        }

        public IEnumerable<CarDto> GetAllCarsWithoutSorting()
        {
            var carDtos = new List<CarDto>();

            foreach (var car in this.carsRepository.All())
            {
                var carDto = this.GetCarById(car.Id);

                carDtos.Add(carDto);
            }

            return carDtos;
        }

        //public void AddCategory(string name)
        //{
        //    var categoryEntity = new Category { Name = name };

        //    this.db.Categories.Add(categoryEntity);

        //    this.db.SaveChanges();
        //}

        //public void AddColor(string name)
        //{
        //    var colorEntity = new Color { Name = name };

        //    this.db.Colors.Add(colorEntity);

        //    this.db.SaveChanges();
        //}

        //public void AddEuroStandart(string name)
        //{
        //    var euroStandart = new EuroStandart { Name = name };

        //    this.db.EuroStandarts.Add(euroStandart);

        //    this.db.SaveChanges();
        //}

        //public void AddFuelType(string name)
        //{
        //    var fuelType = new FuelType { Name = name };

        //    this.db.FuelTypes.Add(fuelType);

        //    this.db.SaveChanges();
        //}

        //public void AddGearbox(string name)
        //{
        //    var gearbox = new Gearbox { Name = name };

        //    this.db.Gearboxes.Add(gearbox);

        //    this.db.SaveChanges();
        //}

        //public void AddMake(string name)
        //{
        //    var makeEntity = new Make { Name = name };

        //    this.db.Makes.Add(makeEntity);

        //    this.db.SaveChanges();
        //}
    }
}
