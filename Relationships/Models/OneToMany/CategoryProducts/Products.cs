using Entity_HomeWorks_OneToOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.OneToMany.CategoryProducts
{
    internal class Products : Entity
    {
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
