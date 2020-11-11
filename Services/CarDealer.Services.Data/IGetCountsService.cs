namespace CarDealer.Services.Data
{
    using CarDealer.Services.Data.Models;
    using CarDealer.Web.ViewModels.Home;

    public interface IGetCountsService
    {
        CountsDto GetCounts();
    }
}
