using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizza.DL.Models;

[Table("ORDER_FOOD")]
public class OrderFood
{
    [Key]
    [Column("ID_ORDER_FOOD")]
    public long IdOrderFood { get; set; }
    
    [Required]
    [Column("FK_ORDER")]
    public long FkOrder { get; set; }
    
    [ForeignKey(nameof(FkOrder))]
    public virtual Order? FkOrderNavigation { get; set; }
    
    [Required]
    [Column("FK_FOOD")]
    public long FkFood { get; set; }
    
    [ForeignKey(nameof(FkFood))]
    public virtual Food? FkFoodNavigation { get; set; }
    
    [Column("AMOUNT")]
    public int Amount { get; set; }
}