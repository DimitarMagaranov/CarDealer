using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models.CarModels
{
    public class Make
    {
        public Make()
        {
            this.Models = new HashSet<Model>();
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
