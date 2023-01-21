using DevTec.Poco;

namespace DevTec.Envelope.Modelo
{
    public class EmpresaEnvelope : BaseEnvelope
    {
        public int CodigoEmpresa { get; set; }

        public string Descricao { get; set; } = null!;

        public string CNPJ { get; set; } = null!;

        public string RazaoSocial { get; set; } = null!;

        public EmpresaEnvelope(EmpresaPoco poco)
        {
            CodigoEmpresa = poco.CodigoEmpresa;
            Descricao = poco.Descricao;
            CNPJ = poco.CNPJ;
            RazaoSocial = poco.RazaoSocial;
        }

        public override void SetLinks()
        {
            Links.List = "GET /empresa";
            Links.Self = "GET /empresa/" + CodigoEmpresa.ToString();
            Links.Exclude = "DELETE /empresa/" + CodigoEmpresa.ToString();
            Links.Update = "PUT /empresa";
        }
    }
}
