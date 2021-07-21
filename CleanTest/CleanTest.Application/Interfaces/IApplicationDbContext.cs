using CleanTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanTest.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Campaign> Campaigns { get; set; }
        DbSet<Asset> Assets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
