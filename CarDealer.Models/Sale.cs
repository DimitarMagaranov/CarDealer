namespace CarDealer.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int DaysValidateId { get; set; }
        public DaysValidate DaysValidate { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
