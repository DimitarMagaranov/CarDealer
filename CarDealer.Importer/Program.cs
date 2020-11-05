using CarDealer.Data;
using CarDealer.Importer.JsonDtos;
using CarDealer.Services;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CarDealer.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
            MakesSeeding();
            ColorsSeeding();
            CategoriesSeeding();
            FuelTypesSeeding();
            EuroStandartsSeeding();
            GearboxesSeeding();
        }

        private static void MakesSeeding()
        {
            var json = File.ReadAllText("CarMakesJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<MakeDto>>(json);

            var db = new CarDealerDbContext();

            ICarsService carsService = new CarsService(db);

            foreach (var property in properties)
            {
                try
                {
                    carsService.AddMake(property.Name);
                }
                catch
                {
                }
            }
        }

        private static void ColorsSeeding()
        {
            var json = File.ReadAllText("CarColorsJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<ColorDto>>(json);

            var db = new CarDealerDbContext();

            ICarsService carsService = new CarsService(db);

            foreach (var property in properties)
            {
                try
                {
                    carsService.AddColor(property.Name);
                }
                catch
                {
                }
            }
        }

        private static void CategoriesSeeding()
        {
            var json = File.ReadAllText("CategoriesJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(json);

            var db = new CarDealerDbContext();

            ICarsService carservice = new CarsService(db);

            foreach (var property in properties)
            {
                try
                {
                    carservice.AddCategory(property.Name);
                }
                catch
                {
                }
            }
        }

        private static void FuelTypesSeeding()
        {
            var json = File.ReadAllText("CarFuelTypeJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<FuelTypeDto>>(json);

            var db = new CarDealerDbContext();

            ICarsService carservice = new CarsService(db);

            foreach (var property in properties)
            {
                try
                {
                    carservice.AddFuelType(property.Name);
                }
                catch
                {
                }
            }
        }

        private static void EuroStandartsSeeding()
        {
            var json = File.ReadAllText("CarEuroStandartJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<FuelTypeDto>>(json);

            var db = new CarDealerDbContext();

            ICarsService carservice = new CarsService(db);

            foreach (var property in properties)
            {
                try
                {
                    carservice.AddEuroStandart(property.Name);
                }
                catch
                {
                }
            }
        }

        private static void GearboxesSeeding()
        {
            var json = File.ReadAllText("CarGearboxJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<FuelTypeDto>>(json);

            var db = new CarDealerDbContext();

            ICarsService carservice = new CarsService(db);

            foreach (var property in properties)
            {
                try
                {
                    carservice.AddGearbox(property.Name);
                }
                catch
                {
                }
            }
        }
    }

}
