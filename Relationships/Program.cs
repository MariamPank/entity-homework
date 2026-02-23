using Entity_HomeWorks_OneToOne.Data;
using Relationships.Models.ManyToMany.OrderItem;

namespace Entity_HomeWorks
{
    internal class Program
    {
        private static readonly DataContext _db = new DataContext();
        static void Main(string[] args)
        {
            // პროდუქტები
            var p1 = new Product { Title = "T-Shirt", Price = 50 };
            var p2 = new Product { Title = "Jeans", Price = 120 };

            _db.AddRange(p1, p2);
            _db.SaveChanges();

            // შეკვეთა + items
            var order = new Order
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = p1.Id, Quantity = 2, UnitPrice = p1.Price },
                    new OrderItem { ProductId = p2.Id, Quantity = 1, UnitPrice = p2.Price }
                }
            };

            _db.Add(order);
            _db.SaveChanges();
        }
    }
}
