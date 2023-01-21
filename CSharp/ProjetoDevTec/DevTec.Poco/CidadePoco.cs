namespace DevTec.Poco;

public class CidadePoco
    {
        public long CodigoCidade { get; set; }
        public string Nome { get; set; } = null!;
        public long CodigoIBGE7 { get; set; }
        public long CodigoEstado { get; set; }
        public CidadePoco()
        {
        }
    }
	
