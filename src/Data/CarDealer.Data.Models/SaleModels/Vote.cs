namespace CarDealer.Data.Models.SaleModels
{
    using CarDealer.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
