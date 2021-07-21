using CleanTest.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTest.Infrastructure.Services
{
    public class CampaingService : ICampaignService
    {
        private readonly IApplicationDbContext _context;
        public CampaingService(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}
