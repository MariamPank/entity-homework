using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.ManyToMany.OrderItem
{
    internal class Order : Entity
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
