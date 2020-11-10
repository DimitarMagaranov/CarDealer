namespace CarDealer.Data.Models.CarModels
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}
