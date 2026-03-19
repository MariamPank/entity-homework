using Inventory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    internal class Product : BaseEntity
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DateTime ExpiresAt { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
