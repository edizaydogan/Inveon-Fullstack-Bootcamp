using Homework1.AsyncAwait;
using Homework1.DIP;
using Homework1.ISP;
using Homework1.LSP;
using Homework1.Methods;
using Homework1.OCP;
using Homework1.SRP;

class Program
{
    static async Task Main()
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



        // DIP Bad Example
        /*
        NotificationService notificationService = new NotificationService();
        notificationService.Notify("Hello, DIP!");
        */

        // DIP Good Example
        IMessageSender emailSender = new EmailSender();
        NotificationService emailNotification = new NotificationService(emailSender);
        emailNotification.Notify("Hello via Email!");

        IMessageSender smsSender = new SmsSender();
        NotificationService smsNotification = new NotificationService(smsSender);
        smsNotification.Notify("Hello via SMS!");



        // Synchorous Method
        /*
        FileDownloaderSynchoronous downloader = new FileDownloaderSynchoronous();
        downloader.DownloadFile();
        */

        // Asynchorous Method
        FileDownloaderAsynchronous downloader = new FileDownloaderAsynchronous();

        Task downloadTask = downloader.DownloadFileAsync();
        Console.WriteLine("You can do other work while the file is downloading.");

        await downloadTask;


        // Task Static Methods
        /*
        Task task = Task.Run(() => Console.WriteLine("Task is running."));
        task.Wait(); // İşin tamamlanmasını bekler

        await Task.Delay(2000); // 2 saniye bekler
        Console.WriteLine("2 seconds passed.");

        Task task1 = Task.Delay(2000);
        Task task2 = Task.Delay(3000);
        await Task.WhenAll(task1, task2);
        Console.WriteLine("Both tasks are completed.");

        Task task3 = Task.Delay(2000);
        Task task4 = Task.Delay(3000);
        await Task.WhenAny(task3, task4);
        Console.WriteLine("At least one task is completed.");

        Task<int> task5 = Task.FromResult(42);
        int result = await task5;
        Console.WriteLine($"Task5 result: {result}");

        Task task6 = Task.CompletedTask;
        Console.WriteLine("Task is already completed.");

        Task task7 = Task.Factory.StartNew(() => Console.WriteLine("Task.Factory.StartNew running."));
        task7.Wait(); // İşin tamamlanmasını bekler

        Console.WriteLine("\nTask.FromException");
        Task failedTask = Task.FromException(new InvalidOperationException("An error occurred"));
        try
        {
            await failedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }

        Console.WriteLine("\nTask.FromCanceled");
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        Task canceledTask = Task.FromCanceled(cancellationTokenSource.Token);
        Console.WriteLine("Canceled task created.");

        Console.WriteLine("\nTask.Yield");
        Console.WriteLine("Before Task.Yield");
        await Task.Yield();
        Console.WriteLine("After Task.Yield");

        Console.WriteLine("\nTask.WaitAll");
        var waitAllTask1 = PerformLongTask("WaitAll Task 1", 1000);
        var waitAllTask2 = PerformLongTask("WaitAll Task 2", 1500);
        Task.WaitAll(waitAllTask1, waitAllTask2);
        Console.WriteLine("All tasks in Task.WaitAll completed.");

        Console.WriteLine("\nTask.WaitAny");
        var waitAnyTask1 = PerformLongTask("WaitAny Task 1", 2000);
        var waitAnyTask2 = PerformLongTask("WaitAny Task 2", 1000);
        int completedTaskIndex = Task.WaitAny(waitAnyTask1, waitAnyTask2);
        Console.WriteLine($"Task.WaitAny completed: Task {completedTaskIndex + 1}");
        */

        FileDownloader fileDownloader = new FileDownloader();

        Console.WriteLine("\nScenario 1: Valid file name");
        await fileDownloader.DownloadFileAsync("example.txt");

        Console.WriteLine("\nScenario 2: Invalid file name");
        await fileDownloader.DownloadFileAsync(""); // Geçersiz dosya adı




    }

    private static async Task PerformLongTask(string taskName, int delay)
    {
        Console.WriteLine($"{taskName} started...");
        await Task.Delay(delay);
        Console.WriteLine($"{taskName} completed.");
    }
}