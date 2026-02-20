using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.OneToMany.UserOrders
{
    internal class Customer : Entity
    {
        public string Name { get; set; }

        public List<Orders> Orders { get; set; } = new();
    }
}
