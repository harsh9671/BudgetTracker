using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker.Models
{
    [Table("Expenses")]
    public class Expenses
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        public int? CategoryID { get; set; }
        public Category? Category { get; set; }


    }
}
