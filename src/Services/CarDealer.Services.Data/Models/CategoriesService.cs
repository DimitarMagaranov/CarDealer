namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            List<SelectListItem> categories = new List<SelectListItem>();

            categories = await this.categoriesRepository.AllAsNoTracking()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();

            categories.Insert(0, new SelectListItem() { Text = "Select category", Value = null });

            return categories;
        }
    }
}
