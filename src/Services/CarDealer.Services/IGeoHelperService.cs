namespace CarDealer.Services
{
    using System.Threading.Tasks;

    public interface IGeoHelperService
    {
        Task<string> GetGeoInfo();

        Task<string> GetIPAddress();
    }
}
