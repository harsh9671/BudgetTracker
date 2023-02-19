using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
namespace BudgetTracker.Models
{
    [Table("Category")]
    public class Category
    {
        
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }


        public List<Expenses>? Expenses { get; set; }


    }
}
