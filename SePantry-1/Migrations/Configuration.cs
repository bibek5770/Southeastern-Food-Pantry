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
        public class InitSecurityDb : DropCreateDatabaseIfModelChanges<UsersContext>
    {
            private void SeedMembership()
            {

                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
               // var roles = (SimpleRoleProvider)Roles.Provider;
                var membership = (SimpleMembershipProvider)Membership.Provider;

                if (!Roles.RoleExists("Admin"))
                {
                    Roles.CreateRole("Admin");
                }
               // if (membership.GetUser("bibek5770", false) == null)
               // {
                    membership.CreateUserAndAccount(
                        "sepantry ", "sepantry1231");
                 //  );

                    if (!Roles.GetRolesForUser("sepantry").Contains("Admin"))
                    {
                        Roles.AddUsersToRoles(new[] { "bibek5770" }, new[] { "Admin" });
                    }
                }
            }

        //protected override void Seed(SePantry_1.Models.UsersContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}
    }
    }
