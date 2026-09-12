/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add one customer and serve
        // Expected Result: Display customer
        Console.WriteLine("Test 1");
        var service = new CustomerServiceSolution (4);
        service.AddNewCustomer();
        service.ServeCustomer();

        // Defect(s) Found: ServeCustomer should get customer before deleting

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers then serve in order
        // Expected Result: Display customers in same order they were added
        Console.WriteLine("Test 2");
        service = new CustomerServiceSolution(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");

        // Defect(s) Found: noee

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: Serve without customer?
        // Expected result: error message
        Console.WriteLine("Test 3)");
        service = new CustomerServiceSolution(4);
        service.ServeCustomer();
        // Defect(s) Found; to check length in serve_customer for error message

        Console.WriteLine("=================");

            // Test 4
        // Scenario: Does max queue size get enforced?
        // Expected Result: Display error message when 5th added
        Console.WriteLine("Test 4");
        service = new CustomerServiceSolution(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Service Queue: {service}");
        // Defect(s) Found: need to do >= instead of > in AddNewCustomer

        Console.WriteLine("=================");


        // Test 5
        // Scenario: DIs max size getting defaulted to 10 if an invalid value is provided?
        // Expected Result: It should display 10
        Console.WriteLine("Test 5");
        service = new CustomerServiceSolution(0);
        Console.WriteLine($"Size should be 10: {service}");
        // Defect(s) Found: None :)
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if(_queue.Count <= 0)
        {
            Console.WriteLine("No Customers in the queue");
        }
        else {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
            }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}