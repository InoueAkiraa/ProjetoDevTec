using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTec.Domain.EF;

[Table("Cidade", Schema = "dbo")]
    public partial class Cidade
    {
        [Key]
        [Column(name: "CodigoCidade")]
        public int CodigoCidade { get; set; }

        [Column(name: "Nome")]
        [Unicode(false)]
        public string Nome { get; set; } = null!;

        [Column(name: "CodigoIBGE7")]
        public int CodigoIBGE7 { get; set; }

        [Column(name: "CodigoEstado")]
        public int CodigoEstado { get; set; }
    }
