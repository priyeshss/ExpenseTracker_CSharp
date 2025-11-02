using ExpenseTracker.Services;

class Program
{
    static void Main()
    {
        ExpenseManager manager = new ExpenseManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== Expense Tracker ===");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View All Expenses");
            Console.WriteLine("3. View Summary by Category");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddExpense(manager);
                    break;
                case "2":
                    manager.ListExpenses();
                    break;
                case "3":
                    manager.ShowSummary();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void AddExpense(ExpenseManager manager)
    {
        Console.Write("Enter description: ");
        string? desc = Console.ReadLine();

        Console.Write("Enter amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount!");
            return;
        }

        Console.Write("Enter category: ");
        string? category = Console.ReadLine();

        manager.AddExpense(desc ?? "N/A", amount, category ?? "General");
        Console.WriteLine("Expense added successfully!");
    }
}
