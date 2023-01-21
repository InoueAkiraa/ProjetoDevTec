using DevTec.Poco;

namespace DevTec.Envelope.Modelo
{
    public class TipoPessoaEnvelope : BaseEnvelope
    {
        public int CodigoTipoPessoa { get; set; }

        public string Descricao { get; set; } = null!;

        public string SiglaTipoPessoa { get; set; } = null!;

        public TipoPessoaEnvelope(TipoPessoaPoco poco)
        {
            CodigoTipoPessoa = poco.CodigoTipoPessoa;
            Descricao = poco.Descricao;
            SiglaTipoPessoa = poco.SiglaTipoPessoa;
        }

        public override void SetLinks()
        {
            Links.List = "GET /tipopessoa";
            Links.Self = "GET /tipopessoa/" + CodigoTipoPessoa.ToString();
            Links.Exclude = "DELETE /tipopessoa/" + CodigoTipoPessoa.ToString();
            Links.Update = "PUT /tipopessoa";
        }
    }
}
