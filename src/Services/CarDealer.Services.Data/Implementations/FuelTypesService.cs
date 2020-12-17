namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class FuelTypesService : IFuelTypesService
    {
        private readonly IRepository<FuelType> fuelTypesRepository;

        public FuelTypesService(IRepository<FuelType> fuelTypesRepository)
        {
            this.fuelTypesRepository = fuelTypesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync()
        {
            var fuelTypes = new List<KeyValuePair<string, string>>();

            fuelTypes = await this.fuelTypesRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()))
                .ToListAsync();

            fuelTypes.Insert(0, new KeyValuePair<string, string>("Select fuel type", null));

            return fuelTypes;
        }
    }
}
