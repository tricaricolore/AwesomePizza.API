using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizza.DL.Models;

[Table("STATUS")]
[Index(nameof(Code), IsUnique = true)]
public class Status
{
    [Key]
    [Column("ID_STATUS")]
    public long IdStatus { get; set; }

    [Required]
    [Column("CODE")]
    [MaxLength(3)]
    public string Code { get; set; } = null!;

    [Required]
    [Column("DESCRIPTION")]
    [MaxLength(200)]
    public string Description { get; set; } = null!;
}