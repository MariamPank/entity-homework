using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.Products
{
    internal interface IProductService
    {
        void CreateProduct();
        void DeleteProduct();
        void EditProduct();
        void ShowProducts();
        void FilterProducts();
        void OrderByPrice();
    }
}
