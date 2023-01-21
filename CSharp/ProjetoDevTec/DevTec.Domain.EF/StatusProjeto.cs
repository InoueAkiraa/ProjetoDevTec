using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF;

[Table("StatusProjeto", Schema = "dbo")]

public partial class StatusProjeto
{
    //[CodigoStatusProjeto] [int] IDENTITY(1,1) NOT NULL,
    //[Descricao] [varchar](25) NOT NULL,
    //[SiglaStatusProjeto] [char](2) NOT NULL,

    [Key]
    public int CodigoStatusProjeto { get; set; }

    [Column(name: "Descricao")]
    [Unicode(false)]
    [StringLength(25)]
    public string Descricao { get; set; } = null!;

    [Column(name: "SiglaStatusProjeto")]
    [Unicode(false)]
    [StringLength(2)]
    public string SiglaStatusProjeto { get; set; } = null!;
}
