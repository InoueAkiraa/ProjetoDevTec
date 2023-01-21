using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTec.Domain.EF
{
    [Table("Profissao", Schema = "dbo")]
    public partial class Profissao
    {
        [Key]
        [Column(name: "CodigoProfissao")]
        public int CodigoProfissao { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        [StringLength(100)]
        public string Descricao { get; set; } = null!;

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }

        [Column(name: "Ativo")]
        public bool? Ativo { get; set; }
    }
}
