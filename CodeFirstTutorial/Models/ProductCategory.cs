using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstTutorial.Models;

public class ProductCategory
{
    [Key]
    [ForeignKey("Categories")]
    [Column("FK_category")]
    public int CategoryId { get; set; }
    
    [Key]
    [ForeignKey("Products")]
    [Column("FK_product")]
    public int ProductId { get; set; }
    
    
    public Category Category { get; set; }
    public Product Product { get; set; }
}