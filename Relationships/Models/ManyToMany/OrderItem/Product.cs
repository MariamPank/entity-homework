using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.ManyToMany.OrderItem
{
    internal class Product : Entity
    {
        public string Title { get; set; } = "";
        public decimal Price { get; set; }

        public List<OrderItem> OrderItems { get; set;} = new List<OrderItem>();
    }
}
