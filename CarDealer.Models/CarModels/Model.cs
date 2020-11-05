using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models.CarModels
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int MakeId { get; set; }
        public virtual Make Make { get; set; }
    }
}
