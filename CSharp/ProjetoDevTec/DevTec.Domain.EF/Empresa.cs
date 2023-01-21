using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF;

[Table("Empresa", Schema = "dbo")]

public partial class Empresa
{

    [Key]
    public int CodigoEmpresa { get; set; }

    [Column(name: "Descricao")]
    [Unicode(false)]
    [StringLength(50)]
    public string Descricao { get; set; } = null!;

    [Column(name: "CNPJ")]
    [Unicode(false)]
    [StringLength(18)]
    public string CNPJ { get; set; } = null!;

    [Column(name: "RazaoSocial")]
    [Unicode(false)]
    [StringLength(50)]
    public string RazaoSocial { get; set; } = null!;
}
