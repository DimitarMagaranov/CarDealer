namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class FuelTypesService : IFuelTypesService
    {
        private readonly IRepository<FuelType> fuelTypesSepository;

        public FuelTypesService(IRepository<FuelType> fuelTypesSepository)
        {
            this.fuelTypesSepository = fuelTypesSepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync()
        {
            var fuelTypes = await this.fuelTypesSepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToListAsync();

            var data = fuelTypes.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select fuel type"));

            return data;
        }
    }
}
