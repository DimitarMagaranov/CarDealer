namespace CarDealer.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task SetVoteAsync(int saleId, string userId, byte value);

        double GetAverageVotes(int saleId);
    }
}
