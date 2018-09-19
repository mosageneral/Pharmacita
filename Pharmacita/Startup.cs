using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Pharmacita.Models;

[assembly: OwinStartupAttribute(typeof(Pharmacita.Startup))]
namespace Pharmacita
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRole();
            CreateUsers();
            CreateUsers1();
            CreateUsers2();
            CreateUsers3();
        }
        public void CreateUsers()
        {
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "admin@Pharmacita.com";
            user.UserName = "admin@Pharmacita.com";
            
          
            var check = usermanger.Create(user, "123456789Admin@");
            if (check.Succeeded)
            {
                usermanger.AddToRole(user.Id, "Admins");
            }
        }
        public void CreateUsers1()
        {
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "Mangers1@Pharmacita.com";
            user.UserName = "Mangers1@Pharmacita.com";
          
            var check = usermanger.Create(user, "123456789Mangers@");
            if (check.Succeeded)
            {
                usermanger.AddToRole(user.Id, "Admins");
            }
        }
        public void CreateUsers2()
        {
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "Mangers2@Pharmacita.com";
            user.UserName = "Mangers2@Pharmacita.com";
           
            var check = usermanger.Create(user, "123456789Mangers@");
            if (check.Succeeded)
            {
                usermanger.AddToRole(user.Id, "Admins");
            }
        }
        public void CreateUsers3()
        {
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "Mangers3@Pharmacita.com";
            user.UserName = "Mangers3@Pharmacita.com";
            
            var check = usermanger.Create(user, "123456789Mangers@");
            if (check.Succeeded)
            {
                usermanger.AddToRole(user.Id, "Admins");
            }
        }

        public void CreateRole()
        {
            var rolemanger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!rolemanger.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                rolemanger.Create(role);

            }
            if (!rolemanger.RoleExists("Users"))
            {
                role = new IdentityRole();
                role.Name = "Users";
                rolemanger.Create(role);

            }
           
        }
    }
}
