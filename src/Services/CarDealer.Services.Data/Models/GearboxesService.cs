namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class GearboxesService : IGearboxesService
    {
        private readonly IRepository<Gearbox> gearboxesRepository;

        public GearboxesService(IRepository<Gearbox> gearboxesRepository)
        {
            this.gearboxesRepository = gearboxesRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            List<SelectListItem> gearBoxes = new List<SelectListItem>();

            gearBoxes = await this.gearboxesRepository.AllAsNoTracking()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();

            gearBoxes.Insert(0, new SelectListItem() { Text = "Select gearbox", Value = null });

            return gearBoxes;
        }
    }
}
