using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.OneToMany.UserOrders
{
    internal class Orders : Entity
    {
        public decimal Total { get; set; }


        public string UserId { get; set; }
        public Customer User { get; set; }
    }
}
