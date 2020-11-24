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

    public class CarGearboxesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Gearboxes.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\Data\CarDealer.Data\Seeding\JsonFiles\CarGearboxJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<GearboxDto>>(json);

            foreach (var property in properties)
            {
                try
                {
                    await dbContext.Gearboxes.AddAsync(new Gearbox { Name = property.Name });
                }
                catch
                {
                }
            }
        }
    }
}
