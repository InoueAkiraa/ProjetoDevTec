using DevTec.Poco;

namespace DevTec.Envelope.Modelo
{
    public class ProfissaoEnvelope : BaseEnvelope
    {
        public int CodigoProfissao { get; set; }

        public string Descricao { get; set; } = null!;

        public DateTime? DataInclusao { get; set; }

        public bool? Ativo { get; set; }

        public ProfissaoEnvelope(ProfissaoPoco poco)
        {
            CodigoProfissao = poco.CodigoProfissao;
            Descricao = poco.Descricao;
            DataInclusao = poco.DataInclusao;
            Ativo = poco.Ativo;
        }

        public override void SetLinks()
        {
            Links.List = "GET /profissao";
            Links.Self = "GET /profissao/" + CodigoProfissao.ToString();
            Links.Exclude = "DELETE /profissao/" + CodigoProfissao.ToString();
            Links.Update = "PUT /profissao";
        }
    }
}
