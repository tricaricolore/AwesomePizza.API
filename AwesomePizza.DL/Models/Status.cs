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
    public required string Code { get; set; }

    [Required]
    [Column("DESCRIPTION")]
    [MaxLength(200)]
    public required string Description { get; set; }
}