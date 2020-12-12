namespace CarDealer.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Votes;
    using CarDealer.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVotesService votesService;

        public VotesController(IVotesService votesService)
        {
            this.votesService = votesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.votesService.SetVoteAsync(input.SaleId, userId, input.Value);
            var averageVotes = this.votesService.GetAverageVotes(input.SaleId);
            return new PostVoteResponseModel { AverageVote = averageVotes };
        }
    }
}
