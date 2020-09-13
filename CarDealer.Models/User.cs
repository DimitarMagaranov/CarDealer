namespace CarDealer.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
