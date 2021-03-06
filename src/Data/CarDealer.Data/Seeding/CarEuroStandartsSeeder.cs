﻿namespace CarDealer.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    using CarDealer.Data.Models.CarModels;
    using CarDealer.Data.Seeding.Dtos;

    public class CarEuroStandartsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.EuroStandarts.Any())
            {
                return;
            }

            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\src\Data\CarDealer.Data\Seeding\JsonFiles\CarEuroStandartJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<EuroStandartDto>>(json);

            foreach (var property in properties)
            {
                try
                {
                    await dbContext.EuroStandarts.AddAsync(new EuroStandart { Name = property.Name });
                }
                catch
                {
                }
            }
        }
    }
}
