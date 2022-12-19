using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWorkspace.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Yanlış Değer")]
        public int Amount { get; set; }

        [DisplayName("Category ID")]
        public int C_Id {get; set;}
        [ForeignKey("C_Id")]
        [ValidateNever]
        public ExpenseCategory ExpenseCategory {get; set;}
    }
}
