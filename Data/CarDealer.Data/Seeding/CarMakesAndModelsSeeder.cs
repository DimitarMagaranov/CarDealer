namespace CarDealer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    using CarDealer.Data.Models.CarModels;

    public class CarMakesAndModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\Data\CarDealer.Data\Seeding\JsonFiles\AllCountriesAndCitiesJsonImprorterFile.json");

            var properties = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

            foreach (var property in properties)
            {
                try
                {
                    var make = new Make { Name = property.Key };
                    var models = new List<Model>();

                    foreach (var modelName in property.Value)
                    {
                        models.Add(new Model { Name = modelName });
                    }

                    make.Models = models;

                    await dbContext.Makes.AddAsync(make);
                }
                catch
                {
                }
            }
        }
    }
}
