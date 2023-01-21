using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevTec.Service.Base;
using DevTec.Domain.EF;
using DevTec.Poco;
using System.Linq.Expressions;

namespace DevTec.Service.Recursos;

public class PessoaProjetoServico : ServicoGenerico<PessoaProjeto, PessoaProjetoPoco>
{
    public PessoaProjetoServico(DevTecContext contexto) : base(contexto)
    { }

    public override List<PessoaProjetoPoco> Consultar(Expression<Func<PessoaProjeto, bool>>? predicate = null)
    {
        IQueryable<PessoaProjeto> query;
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

    public override List<PessoaProjetoPoco> Listar(int? take = null, int? skip = null)
    {
        IQueryable<PessoaProjeto> query;
        if (skip == null)
        {
            query = this.genrepo.GetAll();
        }
        else
        {
            query = this.genrepo.GetAll(take, skip);
        }
        return ConverterPara(query);
    }

    public override List<PessoaProjetoPoco> ConverterPara(IQueryable<PessoaProjeto> query)
    {
        return query.Select(end =>
                new PessoaProjetoPoco()
                {
                    CodigoPessoaProjeto = end.CodigoPessoaProjeto,
                    CodigoPessoa = end.CodigoPessoa,
                    CodigoProjeto = end.CodigoProjeto
                }
        )
        .ToList();
    }
}
