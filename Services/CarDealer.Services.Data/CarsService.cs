namespace CarDealer.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Web.ViewModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Car CreateCar(AddCarInputModel input)
        {
            var carToAdd = new Car
            {
                MakeId = input.MakeId,
                CategoryId = input.CategoryId,
                FuelTypeId = input.FuelTypeId,
                EngineSize = input.EngineSize,
                EuroStandartId = input.EuroStandartId,
                GearboxId = input.GearboxId,
                ColorId = input.ColorId,
                Doors = (Doors)Enum.Parse(typeof(Doors), input.Doors),
                State = (State)Enum.Parse(typeof(State), input.State),
                Mileage = input.Mileage,
                ManufactureDate = input.ManufactureDate,
            };

            this.db.Cars.Add(carToAdd);

            this.db.SaveChanges();

            return carToAdd;
        }

        public void RemoveCarById(int carId)
        {
            var carToDelete = this.db.Cars.FirstOrDefault(x => x.Id == carId);

            this.db.Cars.Remove(carToDelete);

            this.db.SaveChanges();
        }

        public CarViewModel GetCarById(int id)
        {
            var car = this.db.Cars.FirstOrDefault(x => x.Id == id);

            var carViewModel = new CarViewModel
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

            return carViewModel;
        }

        public IEnumerable<CarViewModel> GetAllCarsWithoutSorting()
        {
            var cars = new List<CarViewModel>();

            foreach (var car in this.db.Cars)
            {
                var carViewModel = this.GetCarById(car.Id);

                cars.Add(carViewModel);
            }

            return cars;
        }

        public void AddCategory(string name)
        {
            var categoryEntity = new Category { Name = name };

            this.db.Categories.Add(categoryEntity);

            this.db.SaveChanges();
        }

        public void AddColor(string name)
        {
            var colorEntity = new Color { Name = name };

            this.db.Colors.Add(colorEntity);

            this.db.SaveChanges();
        }

        public void AddEuroStandart(string name)
        {
            var euroStandart = new EuroStandart { Name = name };

            this.db.EuroStandarts.Add(euroStandart);

            this.db.SaveChanges();
        }

        public void AddFuelType(string name)
        {
            var fuelType = new FuelType { Name = name };

            this.db.FuelTypes.Add(fuelType);

            this.db.SaveChanges();
        }

        public void AddGearbox(string name)
        {
            var gearbox = new Gearbox { Name = name };

            this.db.Gearboxes.Add(gearbox);

            this.db.SaveChanges();
        }

        public void AddMake(string name)
        {
            var makeEntity = new Make { Name = name };

            this.db.Makes.Add(makeEntity);

            this.db.SaveChanges();
        }
    }
}
