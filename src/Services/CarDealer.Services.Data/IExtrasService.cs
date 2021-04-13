namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    using CarDealer.Web.ViewModels.Cars.CarExtras;

    public interface IExtrasService
    {
        IEnumerable<ExtraViewModel> GetAllExtras();
    }
}
