namespace DevTec.Envelope.Motor
{
    using Newtonsoft.Json;

    public class StatusRetorno
    {
        [JsonProperty(propertyName: "codigo")]
        public int? Codigo { get; set; }

        [JsonProperty(propertyName: "mensagem")]
        public string Mensagem { get; set; }
    }
}
