using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF;

[Table("TipoProjeto", Schema = "dbo")]

public partial class TipoProjeto
{
    //[[CodigoTipoProjeto] [int] IDENTITY(1,1) NOT NULL,
    //[Descricao] [varchar](50) NOT NULL,
    //[Linguagem] [varchar](25) NOT NULL,

    [Key]
    public int CodigoTipoProjeto { get; set; }

    [Column(name: "Descricao")]
    [Unicode(false)]
    [StringLength(50)]
    public string Descricao { get; set; } = null!;

    [Unicode(false)]
    [StringLength(25)]
    public string Linguagem { get; set; } = null!;
}
