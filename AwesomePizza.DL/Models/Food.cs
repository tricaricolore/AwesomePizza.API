using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizza.DL.Models;

[Table("FOOD")]
public class Food
{
    [Key]
    [Column("ID_FOOD")]
    public long IdFood { get; set; }
    
    [Required]
    [Column("CODE")]
    public Guid Code { get; set; }
    
    [Required]
    [Column("NAME")]
    [MaxLength(200)]
    public required string Name { get; set; }
    
    [Required]
    [Column("DESCRIPTION")]
    [MaxLength(500)]
    public required string Description { get; set; }
    
    [Required]
    [Column("PRICE")]
    public required double Price { get; set; }

    [Required]
    [Column("FK_TYPE")]
    public long FkType { get; set; }
    
    [ForeignKey(nameof(FkType))]
    public virtual FoodType? FkTypeNavigation { get; set; }
    
    [InverseProperty("FkFoodNavigation")]
    public ICollection<FoodIngredient> FoodIngredients { get; set; }
}