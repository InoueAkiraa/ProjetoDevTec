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
    public class StatusProjetoServico : ServicoGenerico<StatusProjeto, StatusProjetoPoco>
    {
        public StatusProjetoServico(DevTecContext contexto) : base(contexto)
        { }

        public override List<StatusProjetoPoco> Consultar(Expression<Func<StatusProjeto, bool>>? predicate = null)
        {
            IQueryable<StatusProjeto> query;
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

        public override List<StatusProjetoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<StatusProjeto> query;
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

        public override List<StatusProjetoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<StatusProjeto, bool>>? predicate = null)
        {
            IQueryable<StatusProjeto> query;
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

        public override List<StatusProjetoPoco> ConverterPara(IQueryable<StatusProjeto> query)
        {
            return query.Select(spr =>
                new StatusProjetoPoco()
                {
                    CodigoStatusProjeto = spr.CodigoStatusProjeto,
                    Descricao = spr.Descricao,
                    SiglaStatusProjeto = spr.SiglaStatusProjeto
                }).ToList();
        }
    }
}
