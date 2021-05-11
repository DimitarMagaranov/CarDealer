namespace CarDealer.Services.Data
{
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

    public interface IModelsService
    {
        Task<ModelViewModel> GetById(int id);

        Task<string> GetModelNameByCarId(int id);
    }
}
