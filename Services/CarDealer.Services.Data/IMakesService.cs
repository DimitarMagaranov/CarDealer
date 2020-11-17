namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMakesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairs();
    }
}
