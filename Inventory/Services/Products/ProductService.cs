using Inventory.Data;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.Products
{
    internal class ProductService : IProductService
    {
        DataContext _db = new DataContext();
        public void CreateProduct()
        {
            Console.Write("Enter the Product Title: ");
            var title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty!");
                return;
            }

            int stock;
            Console.Write("Enter the Quantity: ");
            while (!int.TryParse(Console.ReadLine(), out stock))
            {
                Console.Write("Invalid input. Enter a valid number: ");
            }
            if (stock < 0)
            {
                Console.WriteLine("Quantity must be greater or equal 0");
                return;
            }

            double price;
            Console.Write("Enter the Price: ");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Invalid input. Enter a valid price: ");
            }
            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than 0");
                return;
            }

            DateTime expiresAt;
            Console.Write("Enter the Expiration Date (yyyy-MM-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out expiresAt))
            {
                Console.Write("Invalid date format. Try again: ");
            }

            if (expiresAt <= DateTime.Now)
            {
                Console.WriteLine("Expiration date must be in the future!");
                return;
            }

            var product = new Product()
            {
                Title = title,
                Stock = stock,
                Price = price,
                ExpiresAt = expiresAt
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            Console.WriteLine("Product has been added successfully");
        }

        public void DeleteProduct()
        {
            int productId;
            Console.Write("Please enter the Id of the product, you want to delete: ");
            while(!int.TryParse(Console.ReadLine(),out productId))
            {
                Console.Write("Invalid input. Enter a valid Id: ");
            }
            
            var prodDelete = _db.Products.FirstOrDefault(x => x.Id == productId);

            if (prodDelete == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            _db.Products.Remove(prodDelete);
            _db.SaveChanges();
            Console.WriteLine("Product deleted successfully");
        }

        public void EditProduct()
        {
            int productId;
            Console.Write("Enter the Product Id you want to modify: ");
            while (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.Write("Invalid input. Enter a valid Id: ");
            }

            var prodEdit = _db.Products.FirstOrDefault(x => x.Id == productId);

            if (prodEdit == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            // TITLE
            Console.Write("Enter new Title (leave empty to skip): ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                prodEdit.Title = title;
            }

            // STOCK
            Console.Write("Enter new Quantity (leave empty to skip): ");
            var stockInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(stockInput))
            {
                if (int.TryParse(stockInput, out int stock))
                {
                    if (stock < 0)
                    {
                        Console.WriteLine("Quantity must be >= 0");
                        return;
                    }

                    prodEdit.Stock = stock;
                }
                else
                {
                    Console.WriteLine("Invalid number format");
                    return;
                }
            }

            // PRICE
            Console.Write("Enter new Price (leave empty to skip): ");
            var priceInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (double.TryParse(priceInput, out double price))
                {
                    if (price <= 0)
                    {
                        Console.WriteLine("Price must be greater than 0");
                        return;
                    }

                    prodEdit.Price = price;
                }
                else
                {
                    Console.WriteLine("Invalid price format");
                    return;
                }
            }

            // EXPIRATION DATE
            Console.Write("Enter new Expiration Date (yyyy-MM-dd) (leave empty to skip): ");
            var dateInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(dateInput))
            {
                if (DateTime.TryParse(dateInput, out DateTime expiresAt))
                {
                    if (expiresAt <= DateTime.Now)
                    {
                        Console.WriteLine("Expiration date must be in the future!");
                        return;
                    }

                    prodEdit.ExpiresAt = expiresAt;
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                    return;
                }
            }

            _db.SaveChanges();

            Console.WriteLine("Product updated successfully");
        }

        public void FilterProducts()
        {
            Console.Write("Enter minimum price (or leave empty): ");
            var minPriceInput = Console.ReadLine();

            Console.Write("Enter max price (or leave empty): ");
            var maxPriceInput = Console.ReadLine();

            var query = _db.Products.AsQueryable();

            if (double.TryParse(minPriceInput, out double minPrice))
            {
                query = query.Where(x => x.Price >= minPrice);
            }

            if (double.TryParse(maxPriceInput, out double maxPrice))
            {
                query = query.Where(x => x.Price <= maxPrice);
            }

            var products = query.ToList();

            if (!products.Any())
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} | {product.Title} | {product.Price}");
            }
        }

        public void OrderByPrice()
        {
            Console.Write("Choose sorting: 1 - Ascending, 2 - Descending: ");
            var choice = Console.ReadLine();

            var query = _db.Products.AsQueryable();

            if (choice == "1")
            {
                query = query.OrderBy(x => x.Price);
            }
            else if (choice == "2")
            {
                query = query.OrderByDescending(x => x.Price);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            var products = query.ToList();

            if (!products.Any())
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} | {product.Title} | {product.Price}");
            }
        }

        public void ShowProducts()
        {
            var products = _db.Products.ToList();

            if (!products.Any())
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} | {product.Title} | {product.Price}");
            }
        }
    }
}
