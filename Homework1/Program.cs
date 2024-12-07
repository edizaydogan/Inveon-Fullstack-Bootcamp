using Homework1;

class Program
{
    static void Main()
    {
        // SRP Bad Example
        /*
        Order order = new Order { Id = 1, ProductName = "Laptop", Quantity = 2, Price = 1500m };
        Console.WriteLine($"Total Price: {order.CalculateTotalPrice()}");
        order.SaveToFile("order.txt");
        */

        // SRP Example
        Order order = new Order { Id = 1, ProductName = "Laptop", Quantity = 2, Price = 1500m };
        Console.WriteLine($"Total Price: {order.CalculateTotalPrice()}");

        OrderRepository repository = new OrderRepository();
        repository.SaveToFile(order, "order.txt");
    }
}