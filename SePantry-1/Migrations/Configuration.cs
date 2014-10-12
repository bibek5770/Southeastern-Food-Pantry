namespace SePantry_1.Migrations
{
    using SePantry_1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<SePantry_1.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
       

        protected override void Seed(SePantry_1.Models.UsersContext context)
        
        {

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
          
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");

                if (membership.GetUser("sepantry", false) == null)
                {

                    WebSecurity.CreateUserAndAccount("sepantry", "sepantry1231", new
               {
                   FirstName = "southeastern",
                   LastName = "adhikari",
                   Email = "bibek5770@gmail.edu",
                   wNumber = "w0554322"
               });
                    if (!Roles.GetRolesForUser("sepantry").Contains("Admin"))
                    {
                        Roles.AddUsersToRoles(new[] { "sepantry" }, new[] { "Admin" });
                    }
                }
            }       
        }
    }
}
