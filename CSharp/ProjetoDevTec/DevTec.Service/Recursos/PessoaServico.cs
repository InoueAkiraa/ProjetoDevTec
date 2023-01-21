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

public class PessoaServico : ServicoGenerico<Pessoa, PessoaPoco>
{
    public PessoaServico(DevTecContext contexto) : base(contexto)
    { }

    public override List<PessoaPoco> Consultar(Expression<Func<Pessoa, bool>>? predicate = null)
    {
        IQueryable<Pessoa> query;
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

    public override List<PessoaPoco> Listar(int? take = null, int? skip = null)
    {
        IQueryable<Pessoa> query;
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

    public override List<PessoaPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Pessoa, bool>>? predicate = null)
    {
        IQueryable<Pessoa> query;
        if (skip == null)
        {
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
        }
        else
        {
            if (predicate == null)
            {
                query = this.genrepo.GetAll(take, skip);
            }
            else
            {
                query = this.genrepo.Searchable(take, skip, predicate);
            }
        }
        return this.ConverterPara(query);
    }

    public override List<PessoaPoco> ConverterPara(IQueryable<Pessoa> query)
    {
        return query.Select(est =>
            new PessoaPoco()
            {
                CodigoPessoa = est.CodigoPessoa,
                Nome = est.Nome,
                Sobrenome = est.Sobrenome,
                Email = est.Email,
                Telefone = est.Telefone,
                Matricula = est.Matricula,
                Documento = est.Documento,
                CodigoTipoPessoa = est.CodigoTipoPessoa,
                SiglaTipoPessoa = est.SiglaTipoPessoa,
                Ativo = est.Ativo,
                DataInclusao = est.DataInclusao,
                DataContratacao = est.DataContratacao,
            }).ToList();
    }
}
