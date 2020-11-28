namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

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

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            List<SelectListItem> fuelTypes = new List<SelectListItem>();

            fuelTypes = await this.fuelTypesSepository.AllAsNoTracking()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();

            fuelTypes.Insert(0, new SelectListItem() { Text = "Select fuel type", Value = null });

            return fuelTypes;
        }
    }
}
