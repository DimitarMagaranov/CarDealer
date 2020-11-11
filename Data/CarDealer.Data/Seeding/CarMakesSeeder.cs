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
    using Microsoft.EntityFrameworkCore.Internal;

    public class CarMakesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\Data\CarDealer.Data\Seeding\JsonFiles\CarMakesJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<MakeDto>>(json);

            foreach (var property in properties)
            {
                try
                {
                    await dbContext.Makes.AddAsync(new Make { Name = property.Name });
                }
                catch
                {
                }
            }
        }
    }
}
