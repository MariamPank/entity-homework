using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.OneToMany.VendorAddresses
{
    internal class Addresses : Entity
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }


        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
