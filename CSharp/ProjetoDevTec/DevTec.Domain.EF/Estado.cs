using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DevTec.Domain.EF;

[Table("Estado", Schema = "dbo")]
    public partial class Estado
    {
        [Key]
        [Column(name: "CodigoEstado")]
        public int CodigoEstado { get; set; }

        [Column(name: "Nome")]
        [Unicode(false)]
        public string Nome { get; set; } = null!;

        [Column(name: "UF")]
        [Unicode(false)]
        [StringLength(2)]
        public string UF { get; set; } = null!;
    }
