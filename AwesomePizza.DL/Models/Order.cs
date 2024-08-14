using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizza.DL.Models;

[Table("ORDER")]
public class Order: BaseUserInquiry
{
    [Key]
    [Column("ID_ORDER")]
    public long IdOrder { get; set; }

    [Required]
    [Column("CODE")]
    public Guid Code { get; set; }

    [Required]
    [Column("FK_STATUS")]
    public long FkStatus { get; set; }
    
    [ForeignKey(nameof(FkStatus))]
    public virtual Status? FkStatusNavigation { get; set; }
    
    [InverseProperty("FkOrderNavigation")]
    public ICollection<OrderFood> Foods { get; set; }
}