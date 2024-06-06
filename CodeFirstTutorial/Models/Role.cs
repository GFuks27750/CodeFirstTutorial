using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstTutorial.Models;

[Table("Role")]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int RoleId { get; set; }
    
    [MaxLength(100)]
    [Column("Name")]
    public string Name { get; set; }
    
    public IEnumerable<Account> Account { get; set; }
}