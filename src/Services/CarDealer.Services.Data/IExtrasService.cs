namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.Cars.CarExtras;

    public interface IExtrasService
    {
        Task<IEnumerable<ExtraViewModel>> GetAllExtras();
    }
}
