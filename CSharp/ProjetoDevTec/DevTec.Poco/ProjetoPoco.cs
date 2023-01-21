namespace DevTec.Poco;

public class ProjetoPoco
{
    public int CodigoProjeto {get; set;}
    public string Nome {get; set;} = null!;
    public int CodigoEmpresa { get; set; }
    public int CodigoTipoProjeto { get; set; }
    public string Descricao {get; set;} = null!;
    public decimal PrecoListado {get; set;}
    public int CodigoStatusProjeto {get; set;}
    public string SiglaStatusProjeto {get; set;} = null!;
    public bool? Ativo {get; set;} 
    public DateTime? DataInclusao { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime DataEntregaPrevista { get; set; }
}
