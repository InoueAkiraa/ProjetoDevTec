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

public class EnderecoPessoaServico : ServicoGenerico<EnderecoPessoa, EnderecoPessoaPoco>
{
    public EnderecoPessoaServico(DevTecContext contexto) : base(contexto)
    { }

    public override List<EnderecoPessoaPoco> Consultar(Expression<Func<EnderecoPessoa, bool>>? predicate = null)
    {
        IQueryable<EnderecoPessoa> query;
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

    public override List<EnderecoPessoaPoco> Listar(int? take = null, int? skip = null)
    {
        IQueryable<EnderecoPessoa> query;
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

    public override List<EnderecoPessoaPoco> ConverterPara(IQueryable<EnderecoPessoa> query)
    {
        return query.Select(end =>
                new EnderecoPessoaPoco()
                {
                    CodigoEnderecoPessoa = end.CodigoEnderecoPessoa,
                    CodigoEndereco = end.CodigoEndereco,
                    CodigoPessoa = end.CodigoPessoa
                }
        )
        .ToList();
    }
}
