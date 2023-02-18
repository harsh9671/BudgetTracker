using Microsoft.Build.Framework;

namespace BudgetTracker.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }


        public List<Expenses>? Expenses { get; set; }


    }
}
