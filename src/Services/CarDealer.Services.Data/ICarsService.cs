namespace CarDealer.Services.Data
{
    using CarDealer.Data.Models;
    using CarDealer.Services.Data.Dtos;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarsService
    {
        //void AddCategory(string name);

        //void AddColor(string name);

        //void AddMake(string name);

        //void AddFuelType(string name);

        //void AddEuroStandart(string name);

        //void AddGearbox(string name);

        Car CreateCar(AddCarInputModel input);

        Task RemoveCarByIdAsync(int carId);

        CarDto GetCarById(int id);

        IEnumerable<CarDto> GetAllCarsWithoutSorting();
    }
}
