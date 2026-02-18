using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Springer.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required]
    public string CategoryName { get; set; }
}