using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevTec.Domain.EF;
using DevTec.Poco;
using DevTec.Service.Base;

using DevTec.Service.Recursos;

namespace DevTec.Service.Recursos;

public class CidadeServico : ServicoGenerico<Cidade, CidadePoco>
{
    public CidadeServico(DevTecContext contexto) : base(contexto)
    { }

    public override List<CidadePoco> Consultar(Expression<Func<Cidade, bool>>? predicate = null)
    {
        IQueryable<Cidade> query;
        if (predicate == null)
        {
            query = this.genrepo.Browseable(null);
        }
        else
        {
            query = this.genrepo.Browseable(predicate);
        }
        return this.ConverterPara(query);
    }

    public override List<CidadePoco> Listar(int? take = null, int? skip = null)
    {
        IQueryable<Cidade> query;
        if (skip == null)
        {
            query = this.genrepo.GetAll();
        }
        else
        {
            query = this.genrepo.GetAll(take, skip);
        }
        return this.ConverterPara(query);
    }

    public override List<CidadePoco> ConverterPara(IQueryable<Cidade> query)
    {
        return query.Select(cid =>
            new CidadePoco()
            {
                CodigoCidade = cid.CodigoCidade,
                Nome = cid.Nome,
                CodigoIBGE7 = cid.CodigoIBGE7,
                CodigoEstado = cid.CodigoEstado
            }).ToList();
    }
}