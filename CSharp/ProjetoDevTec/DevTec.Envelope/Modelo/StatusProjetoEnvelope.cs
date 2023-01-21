using DevTec.Poco;

namespace DevTec.Envelope.Modelo
{
    public class StatusProjetoEnvelope : BaseEnvelope
    {
        public int CodigoStatusProjeto { get; set; }

        public string Descricao { get; set; } = null!;

        public string SiglaStatusProjeto { get; set; } = null!;

        public StatusProjetoEnvelope(StatusProjetoPoco poco)
        {
            CodigoStatusProjeto = poco.CodigoStatusProjeto;
            Descricao = poco.Descricao;
            SiglaStatusProjeto = poco.SiglaStatusProjeto;
        }
        public override void SetLinks()
        {
            Links.List = "GET /statusprojeto";
            Links.Self = "GET /statusprojeto/" + CodigoStatusProjeto.ToString();
            Links.Exclude = "DELETE /statusprojeto/" + CodigoStatusProjeto.ToString();
            Links.Update = "PUT /statusprojeto";
        }
    }
}
