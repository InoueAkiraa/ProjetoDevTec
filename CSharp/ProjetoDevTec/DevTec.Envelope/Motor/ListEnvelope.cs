namespace DevTec.Envelope.Motor
{
    public class ListEnvelope<T> where T : class
    {
        private EnvelopeGenerico<T> etapa;

        public EnvelopeGenerico<T> Etapa
        {
            get { return etapa; }
        }

        private ListEnvelope()
        {
            etapa = new EnvelopeGenerico<T>();
        }

        public ListEnvelope(List<T> items, int? codigo, string mensagem, string linkCreate, string versao) : this()
        {
            etapa.Dados.AddRange(items);

            etapa.Status.Codigo = codigo;
            etapa.Status.Mensagem = mensagem;

            etapa.Paginacao.TotalReg = items.Count();

            etapa.LinkCreate = linkCreate;
            etapa.Versao = versao;
        }

        //public ListEnvelope(List<T> items, int? codigo, string mensagem, string linkCreate, string versao,
        //    string urlServidor, int? numPagina, int? contadorPagina) : this(items, codigo, mensagem, linkCreate, versao)
        //{
        //    etapa.Dados.AddRange(items);

        //    etapa.Status.Codigo = codigo;
        //    etapa.Status.Mensagem = mensagem;

        //    int ipageSize = contadorPagina.Value;

        //    if (numPagina.HasValue)
        //    {
        //        etapa.Paginacao.PageCount = contadorPagina.Value;
        //        etapa.Paginacao.PageNumber = numPagina.Value;

        //        int inextPage = numPagina.Value + 1;
        //        string nextPage = urlServidor + "?pageNo=" + inextPage.ToString() + "&pageSize=" + ipageSize.ToString();
        //        etapa.Paginacao.HasNext = nextPage;

        //        int iprevPage = (numPagina.Value == 1) ? 0 : numPagina.Value - 1;
        //        string prevPage = string.Empty;
        //        if (iprevPage != 0)
        //        {
        //            prevPage = urlServidor + "?pageNo=" + iprevPage.ToString() + "&pageSize=" + ipageSize.ToString();
        //        }
        //        etapa.Paginacao.HasPrev= prevPage;
        //    }

        //    etapa.Paginacao.TotalReg = items.Count();

        //    etapa.LinkCreate = linkCreate;
        //    etapa.Versao = versao;
        //}


        public ListEnvelope(List<T> items, int? codigo, string mensagem, string linkCreate, string versao,
            string urlServidor, int? salto, int? limite) : this()
        {
            etapa.Dados.AddRange(items);

            etapa.Status.Codigo = codigo;
            etapa.Status.Mensagem = mensagem;

            int tamanhoPagina = limite.Value;
            if (salto.HasValue)
            {
                string urlAnterior = string.Empty;
                if (salto.Value != 0)
                {
                    int anterior = salto.Value - limite.Value;
                    urlAnterior = urlServidor + "?limite=" + tamanhoPagina.ToString() + "&salto=" + anterior.ToString();
                }

                int proximo = salto.Value + limite.Value;
                string urlProximo = urlServidor + "?limite=" + tamanhoPagina.ToString() + "&salto=" + proximo.ToString();

                etapa.Paginacao.HasPrev = urlAnterior;
                etapa.Paginacao.HasNext = urlProximo;
            }
            etapa.Paginacao.TotalPage = (items.Count() / limite.Value);
            etapa.Paginacao.TotalReg = items.Count();

            etapa.LinkCreate = linkCreate;
            etapa.Versao = versao;
        }
    }
}
