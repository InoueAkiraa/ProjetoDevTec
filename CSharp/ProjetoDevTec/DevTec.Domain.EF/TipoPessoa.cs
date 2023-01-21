using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF;

[Table("TipoPessoa", Schema = "dbo")]

public partial class TipoPessoa
{
    //[CodigoTipoPessoa] [int] IDENTITY(1,1) NOT NULL,
    //[Descricao] [varchar](25) NOT NULL,
    //[SiglaTipoPessoa] [char](2) NOT NULL,

    [Key]
    public int CodigoTipoPessoa { get; set; }

    [Column(name: "Descricao")]
    [Unicode(false)]
    [StringLength(25)]
    public string Descricao { get; set; } = null!;

    [Column(name: "SiglaTipoPessoa")]
    [Unicode(false)]
    [StringLength(2)]
    public string SiglaTipoPessoa { get; set; } = null!;
}
