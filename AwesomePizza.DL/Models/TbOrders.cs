using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizza.DL.Models;

[Table("TB_ORDERS")]
public class TbOrders: BaseStoredEntities
{
    [Key]
    [Column("ID_ORDERS")]
    public long IdOrders { get; set; }

    [Required]
    [Column("CODE")]
    public Guid Code { get; set; }

}