using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF
{
    [Table("PessoaProjeto", Schema = "dbo")]
    public partial class PessoaProjeto
    {
        [Key]
		[Column(name: "CodigoPessoaProjeto")]
        public int CodigoPessoaProjeto { get; set; }
		
		[Column(name: "CodigoPessoa")]
		public int CodigoPessoa { get; set; }
		
		[Column(name: "CodigoProjeto")]
		public int CodigoProjeto { get; set; }
    }
}
