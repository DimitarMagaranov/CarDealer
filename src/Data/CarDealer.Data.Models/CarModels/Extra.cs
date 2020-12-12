namespace CarDealer.Data.Models.CarModels
{
    using System.ComponentModel.DataAnnotations;

    using CarDealer.Data.Common.Models;

    public class Extra : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
