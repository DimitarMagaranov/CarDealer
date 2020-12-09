namespace CarDealer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarMakes;
    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;
    using Microsoft.AspNetCore.Mvc;

    public class CarModelsController : BaseController
    {
        private readonly IMakesService makesService;

        public CarModelsController(IMakesService makesService)
        {
            this.makesService = makesService;
        }

        public async Task<IActionResult> GetModels(int id)
        {
            var data = await this.makesService.GetMakeWithModelsAsync(id);
            var viewModelList = data.Select(x => new MakeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Models = x.Models.Select(m => new ModelViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                }),
            });

            var result = viewModelList.FirstOrDefault(x => x.Id == id).Models;

            return this.Json(result);
        }
    }
}
