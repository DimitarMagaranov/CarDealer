namespace CarDealer.Data.Seeding
{
    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Seeding.Dtos;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class CarColorsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Colors.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\src\Data\CarDealer.Data\Seeding\JsonFiles\CarColorsJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<ColorDto>>(json);

            foreach (var property in properties)
            {
                try
                {
                    await dbContext.Colors.AddAsync(new Color { Name = property.Name });
                }
                catch
                {
                }
            }
        }
    }
}
