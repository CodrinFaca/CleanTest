using CleanTest.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CleanTest.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Extensions;
using CleanTest.Infrastructure.Identity;
using CleanTest.Application.Interfaces;

namespace CleanTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            services.TryAddScoped<UserManager<ApplicationUser>>();
            services.TryAddScoped<SignInManager<ApplicationUser>>();
            services.TryAddScoped<RoleManager<IdentityRole>>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddTransient<IDbInitializer, DbInitializer>();

            //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //        options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDefaultIdentity<ApplicationUser>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //inject db stuff

            return services;
        }
    }
}
