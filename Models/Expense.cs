using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Description} - ₹{Amount} ({Category}) on {Date.ToShortDateString()}";
        }
    }
}
