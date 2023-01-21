namespace DevTec.Poco;

public class PessoaPoco
{
    public int CodigoPessoa { get; set; }
    public string Nome { get; set; } = null!;
    public string Sobrenome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public int? Matricula { get; set; }
    public string Documento { get; set; } = null!;
    public int CodigoTipoPessoa { get; set; }
    public string SiglaTipoPessoa { get; set; } = null!;
    public bool? Ativo { get; set; }
    public DateTime? DataInclusao { get; set; }
    public DateTime? DataContratacao { get; set; }
}
