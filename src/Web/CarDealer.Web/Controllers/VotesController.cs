﻿namespace CarDealer.Web.Controllers
{
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Votes;
    using CarDealer.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

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

            var averageVote = this.votesService.GetAverageVotes(input.SaleId);

            return new PostVoteResponseModel { AverageVote = averageVote };
        }
    }
}