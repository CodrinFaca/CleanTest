using CleanTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanTest.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
    }
}
