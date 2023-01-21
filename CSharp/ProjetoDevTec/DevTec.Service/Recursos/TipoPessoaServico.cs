using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevTec.Service.Base;
using DevTec.Domain.EF;
using DevTec.Poco;
using System.Linq.Expressions;

namespace DevTec.Service.Recursos
{
    public class TipoPessoaServico : ServicoGenerico<TipoPessoa, TipoPessoaPoco>
    {
        public TipoPessoaServico(DevTecContext contexto) : base(contexto)
        { }

        public override List<TipoPessoaPoco> Consultar(Expression<Func<TipoPessoa, bool>>? predicate = null)
        {
            IQueryable<TipoPessoa> query;
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

        public override List<TipoPessoaPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoPessoa> query;
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

        public override List<TipoPessoaPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoPessoa, bool>>? predicate = null)
        {
            IQueryable<TipoPessoa> query;
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

        public override List<TipoPessoaPoco> ConverterPara(IQueryable<TipoPessoa> query)
        {
            return query.Select(tpe =>
                new TipoPessoaPoco()
                {
                    CodigoTipoPessoa = tpe.CodigoTipoPessoa,
                    Descricao = tpe.Descricao,
                    SiglaTipoPessoa = tpe.SiglaTipoPessoa
                }).ToList();
        }
    }
}