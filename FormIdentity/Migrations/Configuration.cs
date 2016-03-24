namespace FormIdentity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FormIdentity.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<FormIdentity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FormIdentity.Models.ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var PasswordHash = new PasswordHasher();

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {

                var admin = new ApplicationUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    PasswordHash = PasswordHash.HashPassword("123456")
                };
                var user1 = new ApplicationUser
               {
                   Email = "user@user.com",
                   UserName = "user@user.com",
                   PasswordHash = PasswordHash.HashPassword("123456")
               };
                UserManager.Create(admin);
                UserManager.Create(user1);
                UserManager.AddToRole(admin.Id, "Admin");
            }
        }
    }
}
