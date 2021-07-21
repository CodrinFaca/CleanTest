using CleanTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanTest.Domain.Entities
{
    public class Asset : BaseEntity
    {
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }
        //ADD name, type, location on disk, createdByUser, createdDateTime
    }
}
