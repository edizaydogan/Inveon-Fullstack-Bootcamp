using Homework1.ISP;
using Homework1.LSP;
using Homework1.OCP;
using Homework1.SRP;

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

        // SRP Good Example
        Order order = new Order { Id = 1, ProductName = "Laptop", Quantity = 2, Price = 1500m };
        Console.WriteLine($"Total Price: {order.CalculateTotalPrice()}");

        OrderRepository repository = new OrderRepository();
        repository.SaveToFile(order, "order.txt");



        // OCP Bad Example 
        /*
        DiscountCalculator calculator = new DiscountCalculator();
        Console.WriteLine($"Seasonal Discount: {calculator.CalculateDiscount("Seasonal", 100)}");
        Console.WriteLine($"Clearance Discount: {calculator.CalculateDiscount("Clearance", 100)}");
        */

        // OCP Good Example
        // Seasonal Discount
        IDiscountStrategy seasonal = new SeasonalDiscount();
        DiscountCalculator seasonalCalculator = new DiscountCalculator(seasonal);
        Console.WriteLine($"Seasonal Discount: {seasonalCalculator.CalculateDiscount(100)}");

        // Clearance Discount
        IDiscountStrategy clearance = new ClearanceDiscount();
        DiscountCalculator clearanceCalculator = new DiscountCalculator(clearance);
        Console.WriteLine($"Clearance Discount: {clearanceCalculator.CalculateDiscount(100)}");



        // LSP Bad Example
        /*
        Bird eagle = new Eagle();
        eagle.Fly();

        Bird penguin = new Penguin();
        // Bu satır çalışma zamanında hata verir
        penguin.Fly();
        */

        // LSP Good Example
        Bird eagle = new Eagle();
        eagle.MakeSound();
        ((IFlyingBird)eagle).Fly();

        Bird penguin = new Penguin();
        penguin.MakeSound();



        // ISP Bad Example
        /*
        IWorker officeWorker = new OfficeWorker();
        officeWorker.Work();
        officeWorker.TakeBreak();

        IWorker robot = new Robot();
        robot.Work();
        robot.TakeBreak();
        */

        // ISP Good Example
        IWorkable officeWorker = new OfficeWorker();
        officeWorker.Work();
        ((IRestable)officeWorker).TakeBreak();

        IWorkable robot = new Robot();
        robot.Work();


    }
}