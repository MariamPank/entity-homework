using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Models.OneToMany.CategoryProducts
{
    internal class Category
    {
        public string CategoryName { get; set; }

        public List<Products> Products { get; set; } = new();
    }
}
