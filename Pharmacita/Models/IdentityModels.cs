using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Pharmacita.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
     
      
        
      
        public string ProfilePic { get; set; }

       
        public int Mobile { get; set; }

     
        public string Address { get; set; }

        public virtual ICollection <Drug> drugs { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Pharmacita.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Pharmacita.Models.Drug> Drugs { get; set; }

        public System.Data.Entity.DbSet<Pharmacita.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<Pharmacita.Models.BuyTheDrug> BuyTheDrugs { get; set; }

        public System.Data.Entity.DbSet<Pharmacita.Models.DrugFind> DrugFinds { get; set; }

        
    }
}