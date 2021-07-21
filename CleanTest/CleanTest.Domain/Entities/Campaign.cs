using CleanTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTest.Domain.Entities
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Country> Countries { get; set; }
        //TODO: add create date, status, etc
    }
}
