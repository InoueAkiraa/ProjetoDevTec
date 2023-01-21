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
    public class TipoProjetoServico : ServicoGenerico<TipoProjeto, TipoProjetoPoco>
    {
        public TipoProjetoServico(DevTecContext contexto) : base(contexto)
        { }

        public override List<TipoProjetoPoco> Consultar(Expression<Func<TipoProjeto, bool>>? predicate = null)
        {
            IQueryable<TipoProjeto> query;
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

        public override List<TipoProjetoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoProjeto> query;
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

        public override List<TipoProjetoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoProjeto, bool>>? predicate = null)
        {
            IQueryable<TipoProjeto> query;
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

        public override List<TipoProjetoPoco> ConverterPara(IQueryable<TipoProjeto> query)
        {
            return query.Select(tpr =>
                new TipoProjetoPoco()
                {
                    CodigoTipoProjeto = tpr.CodigoTipoProjeto,
                    Descricao = tpr.Descricao,
                    Linguagem = tpr.Linguagem
                }).ToList();
        }
    }
}