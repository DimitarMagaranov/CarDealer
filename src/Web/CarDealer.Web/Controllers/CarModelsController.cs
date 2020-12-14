namespace CarDealer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Services.Data;
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

            var result = data.FirstOrDefault(x => x.Id == id).Models;

            return this.Json(result);
        }
    }
}
