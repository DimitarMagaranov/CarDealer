namespace CarDealer.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int saleId)
        {
            return this.votesRepository.All()
                .Where(x => x.SaleId == saleId)
                .Average(x => x.Value);
        }

        public async Task SetVoteAsync(int saleId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.SaleId == saleId && x.UserId == userId);
            if (vote == null)
            {
                vote = new Vote
                {
                    SaleId = saleId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
