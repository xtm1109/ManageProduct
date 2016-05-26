using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ManageProducts.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageProducts.Startup))]
namespace ManageProducts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers() {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Create Admin role and a default Admin User    
            if (!roleManager.RoleExists("Admin")) { // If Admin role is not existed
                // Create Admin role  
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Create a Admin super user               
                var user = new ApplicationUser();
                user.UserName = "admin"; 
                user.Email = "admin@mysite.com";

                string userPWD = "123@123Aa";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded) {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
