namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class ColorsService : IColorsService
    {
        private readonly IRepository<Color> colorsRepository;

        public ColorsService(IRepository<Color> colorsRepository)
        {
            this.colorsRepository = colorsRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            List<SelectListItem> colors = new List<SelectListItem>();

            colors = await this.colorsRepository.AllAsNoTracking()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();

            colors.Insert(0, new SelectListItem() { Text = "Select color", Value = null });

            return colors;
        }
    }
}
