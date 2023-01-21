using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF
{
    [Table("EnderecoPessoa", Schema = "dbo")]
    public partial class EnderecoPessoa
    {
        [Key]
		[Column(name: "CodigoEnderecoPessoa")]
        public int CodigoEnderecoPessoa { get; set; }
		
		[Column(name: "CodigoEndereco")]
		public int CodigoEndereco { get; set; }

		[Column(name: "CodigoPessoa")]
		public int CodigoPessoa { get; set; }
    }
}
