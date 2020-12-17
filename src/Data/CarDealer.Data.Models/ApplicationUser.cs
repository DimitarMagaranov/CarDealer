// ReSharper disable VirtualMemberCallInConstructor
namespace CarDealer.Data.Models
{
    using System;
    using System.Collections.Generic;

    using CarDealer.Data.Common.Models;
    using CarDealer.Data.Models.SaleModels;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Sales = new HashSet<Sale>();
            this.Votes = new HashSet<Vote>();
        }

        public int Age { get; set; }

        public int CountryId { get; set; }

        public int? TempCountryId { get; set; }

        public Country Country { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
