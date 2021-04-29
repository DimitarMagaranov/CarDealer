namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

    public interface IModelsService
    {
        ModelViewModel GetById(int id);

        string GetModelNameByCarId(int id);
    }
}
