using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.DL.Models;

[Table("FOOD_TYPE")]
[Index(nameof(Code), IsUnique = true)]
public class FoodType
{
    [Key]
    [Column("ID_FOOD_TYPE")]
    public long IdFoodType { get; set; }

    [Required]
    [Column("CODE")]
    [MaxLength(3)]
    public required string Code { get; set; }

    [Required]
    [Column("DESCRIPTION")]
    [MaxLength(200)]
    public required string Description { get; set; }
}