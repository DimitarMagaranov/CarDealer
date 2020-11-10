namespace CarDealer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Seeding.Dtos;

    public class CarFuelTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FuelTypes.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\Data\CarDealer.Data\Seeding\JsonFiles\CarFuelTypeJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<FuelTypeDto>>(json);

            foreach (var property in properties)
            {
                try
                {
                    await dbContext.FuelTypes.AddAsync(new FuelType { Name = property.Name });
                }
                catch
                {
                }
            }
        }
    }
}
