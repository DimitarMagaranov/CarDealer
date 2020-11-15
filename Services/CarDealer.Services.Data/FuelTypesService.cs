namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;

    public class FuelTypesService : IFuelTypesService
    {
        private readonly IRepository<FuelType> fuelTypesSepository;

        public FuelTypesService(IRepository<FuelType> fuelTypesSepository)
        {
            this.fuelTypesSepository = fuelTypesSepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            var data = this.fuelTypesSepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select fuel type"));

            return data;
        }
    }
}
