using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanTest.Application.Interfaces;
using CleanTest.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanTest.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Campaign> Campaigns { get; set ; }
        public DbSet<Asset> Assets { get ; set ; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //TODO: check this updated entities stuff: 
            //https://github.com/jasontaylordev/CleanArchitecture/blob/main/src/Infrastructure/Persistence/ApplicationDbContext.cs

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

    }
}
