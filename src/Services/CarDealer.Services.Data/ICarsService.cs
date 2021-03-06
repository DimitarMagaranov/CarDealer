﻿namespace CarDealer.Services.Data
{
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public interface ICarsService
    {
        Car CreateCar(AddCarInputModel input);

        Task<Car> UpdateCarAsync(int id, EditCarInputModel input);

        Task<AddCarInputModel> GetCarInputModelWithFilledListItems();
    }
}
