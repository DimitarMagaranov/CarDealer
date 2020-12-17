namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericsService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync(string strFullyQualifiedName);
    }
}
