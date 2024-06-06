using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstTutorial.Models;

public class ShoppingCart
{
    [Column("amount")]
    public int Amount { get; set; }

    public Account Account { get; set; }
    public Product Product { get; set; }
    
    [Key]
    [ForeignKey("Accounts")]
    [Column("FK_account")]
    public int AccountId { get; set; }
    
    [Key]
    [ForeignKey("Products")]
    [Column("FK_product")]
    public int ProductId { get; set; }
}