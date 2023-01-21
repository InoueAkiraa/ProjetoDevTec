using DevTec.Poco;

namespace DevTec.Envelope.Modelo
{
    public class EstadoEnvelope : BaseEnvelope
    {
        public long CodigoEstado { get; set; }

        public string Nome { get; set; } = null!;

        public string UF { get; set; } = null!;

        public EstadoEnvelope(EstadoPoco poco)
        {
            CodigoEstado = poco.CodigoEstado;
            Nome = poco.Nome;
            UF = poco.UF;
        }

        public override void SetLinks()
        {
            Links.List = "GET /estado";
            Links.Self = "GET /estado/" + CodigoEstado.ToString();
            Links.Exclude = "DELETE /estado/" + CodigoEstado.ToString();
            Links.Update = "PUT /estado";
        }
    }
}
