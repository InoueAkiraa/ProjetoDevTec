using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF;

[Table("Pessoa", Schema = "dbo")]
public partial class Pessoa
{
    [Key]
    public int CodigoPessoa { get; set; }

    [Column(name: "Nome")]
    [Unicode(false)]
    [StringLength(255)]
    public string Nome { get; set; } = null!;

    [Column(name: "Sobrenome")]
    [Unicode(false)]
    [StringLength(255)]
    public string Sobrenome { get; set; } = null!;

    [Column(name: "Email")]
    [Unicode(false)]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column(name: "Telefone")]
    [Unicode(false)]
    [StringLength(25)]
    public string Telefone { get; set; } = null!;

    [Column(name: "Matricula")]
    public int? Matricula { get; set; }

    [Column(name: "Documento")]
    [Unicode(false)]
    [StringLength(20)]
    public string Documento { get; set; } = null!;

    [Column(name: "CodigoTipoPessoa")]
    public int CodigoTipoPessoa { get; set; }

    [Column(name: "SiglaTipoPessoa")]
    [Unicode(false)]
    [StringLength(2)]
    public string SiglaTipoPessoa { get; set; } = null!;

    [Column(name: "Ativo")]
    public bool? Ativo { get; set; }

    [Column(name: "DataInclusao", TypeName = "datetime")]
    public DateTime? DataInclusao { get; set; }

    [Column(name: "DataContratacao", TypeName = "datetime")]
    public DateTime? DataContratacao { get; set; }
}

