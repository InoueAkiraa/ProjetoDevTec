using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevTec.Domain.EF;
using DevTec.Poco;
using DevTec.Service.Base;

namespace DevTec.Service.Recursos;

public class EstadoServico : ServicoGenerico<Estado, EstadoPoco>
{
    public EstadoServico(DevTecContext contexto) : base(contexto)
    { }

    public override List<EstadoPoco> Consultar(Expression<Func<Estado, bool>>? predicate = null)
    {
        IQueryable<Estado> query;
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

    public override List<EstadoPoco> Listar(int? take = null, int? skip = null)
    {
        IQueryable<Estado> query;
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

    public override List<EstadoPoco> ConverterPara(IQueryable<Estado> query)
    {
        return query.Select(est =>
            new EstadoPoco()
            {
                CodigoEstado = est.CodigoEstado,
                Nome = est.Nome,
                UF = est.UF,
            }).ToList();
    }
}