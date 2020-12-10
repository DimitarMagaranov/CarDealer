namespace CarDealer.Services.Data
{
    using CarDealer.Data.Models;
    using CarDealer.Services.Data.Dtos;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarsService
    {
        Car CreateCar(AddCarInputModel input);

        Task<AddCarInputModel> GetCarInputModelWithFilledProperties();
    }
}
