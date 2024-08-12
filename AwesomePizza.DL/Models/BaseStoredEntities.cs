using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizza.DL.Models;

public class BaseStoredEntities
{
    [Required]
    [Column("CREATION_DATE")]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    [Required]
    [Column("CREATION_USER")]
    [MaxLength(500)]
    public string CreationUser { get; set; } = string.Empty;

    [Column("MODIFICATION_DATE")]
    public DateTime? ModificationDate { get; set; }

    [Column("MODIFICATION_USER")]
    [MaxLength(500)]
    public string? ModificationUser { get; set; }

    [Column("DELETION_DATE")]
    public DateTime? DeletionDate { get; set; }

    [Column("DELETION_USER")]
    [MaxLength(500)]
    public string? DeletionUser { get; set; }

    [Column("DELETED")]
    public bool Deleted { get; set; }
}