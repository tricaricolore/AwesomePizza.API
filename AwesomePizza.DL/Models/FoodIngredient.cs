using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizza.DL.Models;

[Table("FOOD_INGREDIENT")]
public class FoodIngredient
{
    [Key]
    [Column("ID_FOOD_INGREDIENT")]
    public long IdFoodIngredient { get; set; }
    
    [Required]
    [Column("FK_FOOD")]
    public long FkFood { get; set; }
    
    [ForeignKey(nameof(FkFood))]
    public virtual Food? FkFoodNavigation { get; set; }
    
    [Required]
    [Column("FK_INGREDIENT")]
    public long FkIngredient { get; set; }
    
    [ForeignKey(nameof(FkIngredient))]
    public virtual Ingredient? FkIngredientNavigation { get; set; }
}