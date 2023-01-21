using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF
{

    [Table("Projeto", Schema = "dbo")]
    public partial class Projeto
    {
        [Key]
        public int CodigoProjeto { get; set; }

        [Column(name: "Nome")]
        [Unicode(false)]
        [StringLength(255)]
        public string Nome { get; set; } = null!;

        [Column(name: "CodigoEmpresa")]
        public int CodigoEmpresa { get; set; }

        [Column(name: "CodigoTipoProjeto")]
        public int CodigoTipoProjeto { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        [StringLength(50)]
        public string Descricao { get; set; } = null!;

        [Column(name: "PrecoListado")]
        public decimal PrecoListado { get; set; }

        [Column(name: "CodigoStatusProjeto")]
        public int CodigoStatusProjeto { get; set; }

        [Column(name: "SiglaStatusProjeto")]
        [Unicode(false)]
        [StringLength(2)]
        public string SiglaStatusProjeto { get; set; } = null!;

        [Column(name: "Ativo")]
        public bool? Ativo { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(name: "DataInicio", TypeName = "datetime")]
        public DateTime? DataInicio { get; set; }

        [Column(name: "DataEntregaPrevista", TypeName = "datetime")]
        public DateTime DataEntregaPrevista { get; set; }
    }
}
