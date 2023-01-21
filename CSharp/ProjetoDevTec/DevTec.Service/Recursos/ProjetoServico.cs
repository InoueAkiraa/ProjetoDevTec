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

public class ProjetoServico : ServicoGenerico<Projeto, ProjetoPoco>
{
    public ProjetoServico(DevTecContext contexto) : base(contexto) 
        { }

        public override List<ProjetoPoco> Consultar(Expression<Func<Projeto, bool>>? predicate = null)
        {
            IQueryable<Projeto> query;
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

        public override List<ProjetoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Projeto> query;
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

        public override List<ProjetoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Projeto, bool>>? predicate = null)
        {
            IQueryable<Projeto> query;
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

        public override List<ProjetoPoco> ConverterPara(IQueryable<Projeto> query)
        {
            return query.Select(pro =>
                new ProjetoPoco()
            {
                CodigoProjeto = pro.CodigoProjeto,
				Nome = pro.Nome,
				CodigoEmpresa = pro.CodigoEmpresa,
				CodigoTipoProjeto = pro.CodigoTipoProjeto,
				Descricao = pro.Descricao,
				PrecoListado = pro.PrecoListado,
				CodigoStatusProjeto = pro.CodigoStatusProjeto,
				SiglaStatusProjeto = pro.SiglaStatusProjeto,
				Ativo = pro.Ativo,
				DataInclusao = pro.DataInclusao,
				DataInicio = pro.DataInicio,
				DataEntregaPrevista = pro.DataEntregaPrevista
            }).ToList();
        }
}
