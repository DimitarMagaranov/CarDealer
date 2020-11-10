namespace CarDealer.Services
{
    using System.Collections.Generic;

    using CarDealer.Data.Models;

    using CarDealer.Web.ViewModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public interface ICarsService
    {
        void AddCategory(string name);

        void AddColor(string name);

        void AddMake(string name);

        void AddFuelType(string name);

        void AddEuroStandart(string name);

        void AddGearbox(string name);

        Car CreateCar(AddCarInputModel input);

        void RemoveCarById(int carId);

        CarViewModel GetCarById(int id);

        IEnumerable<CarViewModel> GetAllCarsWithoutSorting();
    }
}
