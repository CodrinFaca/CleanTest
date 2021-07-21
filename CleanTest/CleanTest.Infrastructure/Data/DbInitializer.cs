using CleanTest.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanTest.Infrastructure.Data
{
    public interface IDbInitializer
    {
        void Initialize();
    }
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void Initialize()
        {
            context.Database.Migrate();
            //seed data
            SeedRoles();
            SeedUsers();

        }

        private void SeedUsers()
        {
            var ADMIN_EMAIL = "admin@hh.com";
            var existingUser = userManager.FindByEmailAsync(ADMIN_EMAIL).Result;
            if (existingUser == null)
            {
                //create admin user
                var user = new ApplicationUser { UserName = "admin", Email = ADMIN_EMAIL, EmailConfirmed = true };
                var result = userManager.CreateAsync(user, "!Adm1n").Result;
                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, UserRoles.Admin).Wait();
                context.SaveChanges();
            }
            else
            {
                if(!userManager.IsInRoleAsync(existingUser, UserRoles.Admin).Result)
                {
                    var roleAdd = userManager.AddToRoleAsync(existingUser, UserRoles.Admin).Result;

                    context.SaveChanges();

                }

            }
        }
        private void SeedRoles()
        {
            var existingRoles = context.Roles.ToList();

            foreach (string role in UserRoles.GetRoles())
            {
                //var roleStore = new RoleStore<IdentityRole>(context);

                if (!existingRoles.Any(r => r.Name == role))
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }
            context.SaveChanges();

        }
    }
}
