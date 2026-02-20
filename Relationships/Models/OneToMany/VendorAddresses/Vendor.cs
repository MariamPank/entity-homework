using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.OneToMany.VendorAddresses
{
    internal class Vendor : Entity
    {
        public string Name { get; set; }

        public List<Addresses> VendorAddresses { get; set; } = new();
    }
}
