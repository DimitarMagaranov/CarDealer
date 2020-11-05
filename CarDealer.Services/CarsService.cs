using CarDealer.Data;
using CarDealer.Models.CarModels;

namespace CarDealer.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarDealerDbContext db;

        public CarsService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void AddCategory(string name)
        {
            var categoryEntity = new Category{ Name = name };

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
