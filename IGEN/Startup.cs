using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using IGEN.Models;

[assembly: OwinStartupAttribute(typeof(IGEN.Startup))]
namespace IGEN
{
    public partial class Startup
    {
        private ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        public Startup()
        {
            context = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateAdmin();
            CreateCreator();
        }
        
        private void CreateRoles()
        {
            if (!roleManager.RoleExists("Visitor"))
            {
                var role = new IdentityRole();
                role.Name = "Visitor";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Creator"))
            {
                var role = new IdentityRole();
                role.Name = "Creator";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }

        private void CreateCreator()
        {
            if(userManager.FindByEmail("creator@creator.com") == null)
            {
                var user = new ApplicationUser();
                user.Email = "creator@creator.com";
                user.UserName = "creator@creator.com";
                string password = "Password1!";
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
                userManager.AddToRole(user.Id, "Creator");
            }
        }
        private void CreateAdmin()
        {
            if(userManager.FindByEmail("admin@admin.com") == null)
            {
                var user = new ApplicationUser();
                user.Email = "admin@admin.com";
                user.UserName = "admin@admin.com";
                string password = "Password1!";
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
