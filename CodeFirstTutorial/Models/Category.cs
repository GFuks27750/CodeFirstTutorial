using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstTutorial.Models;

public class Category
{
    [Key]
    [Column("PK_category")]
    public int CategoryId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public IEnumerable<ProductCategory> ProductCategory { get; set; }
}