using DevTec.Poco;

namespace DevTec.Envelope.Modelo
{
    public class TipoProjetoEnvelope : BaseEnvelope
    {
        public int CodigoTipoProjeto { get; set; }

        public string Descricao { get; set; } = null!;

        public string Linguagem { get; set; } = null!;

        public TipoProjetoEnvelope(TipoProjetoPoco poco)
        {
            CodigoTipoProjeto = poco.CodigoTipoProjeto;
            Descricao = poco.Descricao;
            Linguagem = poco.Linguagem;
        }
        public override void SetLinks()
        {
            Links.List = "GET /tipoprojeto";
            Links.Self = "GET /tipoprojeto/" + CodigoTipoProjeto.ToString();
            Links.Exclude = "DELETE /tipoprojeto/" + CodigoTipoProjeto.ToString();
            Links.Update = "PUT /tipoprojeto";
        }
    }
}
