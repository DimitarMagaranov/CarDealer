//namespace CarDealer.Data.Seeding
//{
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;
//    using System.Text;
//    using System.Text.Json;
//    using System.Threading.Tasks;

//    public class CarMakesAndModelsSeeder : ISeeder
//    {
//        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
//        {
//            if (dbContext.Categories.Any())
//            {
//                return;
//            }

//            var json = File.ReadAllText(@"C:\Users\Dimitar\Desktop\CarDealer\Data\CarDealer.Data\Seeding\JsonFiles\CategoriesJsonImporterFile.json");

//            var properties = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(json);

//            foreach (var property in properties)
//            {
//                try
//                {
//                    await dbContext.Categories.AddAsync(new Category { Name = property.Name });
//                }
//                catch
//                {
//                }
//            }
//        }
//    }
//}
