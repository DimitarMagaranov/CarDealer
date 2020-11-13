namespace CarDealer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    using CarDealer.Data.Models.SaleModels;

    public class AllCountriesAndCitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\Data\CarDealer.Data\Seeding\JsonFiles\AllCountriesAndCitiesJsonImprorterFile.json");

            var properties = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

            foreach (var property in properties)
            {
                try
                {
                    var country = new Country { Name = property.Key };

                    await dbContext.Countries.AddAsync(country);
                    await dbContext.SaveChangesAsync();

                    foreach (var cityName in property.Value)
                    {
                        dbContext.Countries.FirstOrDefault(x => x.Name == country.Name).Cities.Add(new City { Name = cityName });
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
