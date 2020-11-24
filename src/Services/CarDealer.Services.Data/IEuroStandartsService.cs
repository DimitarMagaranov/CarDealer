using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealer.Services.Data
{
    public interface IEuroStandartsService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync();
    }
}
