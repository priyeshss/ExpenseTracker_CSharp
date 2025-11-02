using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public class ExpenseManager
    {
        private List<Expense> expenses = new();
        private readonly string filePath = "expenses.json";

        public ExpenseManager()
        {
            LoadExpenses();
        }

        private void LoadExpenses()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<Expense>>(json);
                if (data != null)
                    expenses = data;
            }
        }

        private void SaveExpenses()
        {
            string json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddExpense(string desc, decimal amount, string category)
        {
            int newId = expenses.Count > 0 ? expenses.Max(e => e.Id) + 1 : 1;
            var expense = new Expense
            {
                Id = newId,
                Description = desc,
                Amount = amount,
                Category = category,
                Date = DateTime.Now
            };
            expenses.Add(expense);
            SaveExpenses();
        }

        public void ListExpenses()
        {
            Console.WriteLine("\n--- All Expenses ---");
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses yet.");
                return;
            }

            foreach (var e in expenses)
                Console.WriteLine(e);
        }

        public void ShowSummary()
        {
            Console.WriteLine("\n--- Expense Summary ---");

            if (expenses.Count == 0)
            {
                Console.WriteLine("No data to summarize.");
                return;
            }

            var summary = expenses
                .GroupBy(e => e.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(x => x.Amount) });

            foreach (var s in summary)
                Console.WriteLine($"{s.Category}: ₹{s.Total}");
        }
    }
}
