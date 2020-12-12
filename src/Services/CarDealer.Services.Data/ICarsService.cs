namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.Cars.CarExtras;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public interface ICarsService
    {
        Car CreateCar(AddCarInputModel input);

        public IEnumerable<ExtraViewModel> GetAllExtras();

        Task<AddCarInputModel> GetCarInputModelWithFilledProperties();
    }
}
