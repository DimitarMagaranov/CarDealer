namespace CarDealer.Data.Models.CarModels
{
    using System.ComponentModel.DataAnnotations;

    public class CarExtra
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public int ExtraId { get; set; }

        public Extra Extra { get; set; }
    }
}
