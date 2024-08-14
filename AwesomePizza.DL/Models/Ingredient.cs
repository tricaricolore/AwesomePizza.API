using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.DL.Models;

[Table("INGREDIENT")]
[Index(nameof(Code), IsUnique = true)]
public class Ingredient
{
    [Key]
    [Column("ID_INGREDIENT")]
    public long IdIngredient { get; set; }

    [Required]
    [Column("CODE")]
    [MaxLength(3)]
    public required string Code { get; set; }

    [Required]
    [Column("DESCRIPTION")]
    [MaxLength(200)]
    public required string Description { get; set; }
}