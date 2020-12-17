namespace CarDealer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Seeding.Dtos;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CarMakesAndModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\src\Data\CarDealer.Data\Seeding\JsonFiles\AllMakesAndModels.json");

            var properties = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<MakeAndModelsDto>>(json);

            foreach (var property in properties)
            {
                try
                {
                    var make = new Make { Name = property.Brand };

                    await dbContext.Makes.AddAsync(make);
                    await dbContext.SaveChangesAsync();

                    foreach (var modelName in property.Models)
                    {
                        dbContext.Makes.FirstOrDefault(x => x.Name == make.Name).Models.Add(new Model { Name = modelName });
                    }

                    await dbContext.SaveChangesAsync();
                }
                catch
                {
                }
            }
        }
    }
}
