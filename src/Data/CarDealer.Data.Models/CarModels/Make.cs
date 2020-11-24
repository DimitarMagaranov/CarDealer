namespace CarDealer.Data.Models.CarModels
{
    using System.Collections.Generic;

    public class Make
    {
        public Make()
        {
            this.Models = new HashSet<Model>();
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
