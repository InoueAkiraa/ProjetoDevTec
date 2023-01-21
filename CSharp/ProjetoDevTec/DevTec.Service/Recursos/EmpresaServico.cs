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
    public class EmpresaServico : ServicoGenerico<Empresa, EmpresaPoco>
    {
        public EmpresaServico(DevTecContext contexto) : base(contexto)
        { }

        public override List<EmpresaPoco> Consultar(Expression<Func<Empresa, bool>>? predicate = null)
        {
            IQueryable<Empresa> query;
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

        public override List<EmpresaPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Empresa> query;
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

        public override List<EmpresaPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Empresa, bool>>? predicate = null)
        {
            IQueryable<Empresa> query;
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

        public override List<EmpresaPoco> ConverterPara(IQueryable<Empresa> query)
        {
            return query.Select(emp =>
                new EmpresaPoco()
                {
                    CodigoEmpresa = emp.CodigoEmpresa,
                    Descricao = emp.Descricao,
                    CNPJ = emp.CNPJ,
                    RazaoSocial = emp.RazaoSocial
                }).ToList();
        }
    }
}