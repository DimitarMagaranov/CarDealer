using System.ComponentModel.DataAnnotations;

namespace CarDealer.Web.ViewModels.InputModels.Votes
{
    public class PostVoteInputModel
    {
        public int SaleId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
