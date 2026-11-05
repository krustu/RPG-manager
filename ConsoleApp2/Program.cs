using System;
using System.Xml.Linq;
class Proram
{
    // Files : ApplicationEntryPoint.cs
    static void Main()
    {
      
            var repository = new InMemoryOrderRepository();
            var service = new OrderService(repository);
            service.Place("Fantasy Book", 19.99m);
            service.Place("Science Fiction Book", 24.99m);
            service.Place("Mystery Book", 14.99m);

            try { service.Place("", 0m); }                                   // только он под try
            catch (ArgumentException ex) { Console.WriteLine($"Rejected: {ex.Message}"); }

            Console.WriteLine($"Total sum of orders: {service.TotalSum():C}");   // сумма должна напечататься
            foreach (var order in repository.GetAll())
            {
                Console.WriteLine($"Order ID: {order.Id}, Product: {order.Product}, Price: {order.Price:C}");
            }
        
        
        
      
    }
}
// Files : Model.cs
public class Order
{
    public int Id { get; set; }
    public string Product { get; set; } = "";
    public decimal Price { get; set; }
}
// Files : Repository.cs
public interface IOrderRepository
{
    void Save(Order order);
    IReadOnlyList<Order> GetAll();
}
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
    public void Save(Order order)
    {
        _orders.Add(order);
    }
    public IReadOnlyList<Order> GetAll()
    {
        return _orders.AsReadOnly();
    }
}
// Files : Service.cs
public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public Order Place(string product, decimal price)
    {
        if(string.IsNullOrWhiteSpace(product))
        {
            throw new ArgumentException("Product name cannot be empty.", nameof(product));
        }
        if(price <= 0)
        {
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        }

        var order = new Order { Id = _orderRepository.GetAll().Count + 1, Product = product, Price = price };
        _orderRepository.Save(order);
        return order;
    }
    public decimal TotalSum() => _orderRepository.GetAll().Sum(o => o.Price);
}


