using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevTec.Domain.EF;
using DevTec.Poco;
using DevTec.Service.Recursos;

namespace DevTecApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/desenvolvimento/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private ProjetoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ProjetoController(DevTecContext context) : base()
        {
            this.servico = new ProjetoServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProjetoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ProjetoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Traz todos os registros de acordo com o código de empresa.
        /// </summary>
        /// <param name="procod"></param>
        /// <returns></returns>
        [HttpGet("PorEmpresa/{procod:int}")]
        public ActionResult<List<ProjetoPoco>> GetByEmpresaId(int procod)
        {
            try
            {
                List<ProjetoPoco> listaPoco = this.servico.Consultar(pro => (pro.CodigoEmpresa == procod)).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Traz todos os registros de acordo com o código de TipoProjeto.
        /// </summary>
        /// <param name="tipcod"></param>
        /// <returns></returns>
        [HttpGet("PorTipoProjeto/{tipcod:int}")]
        public ActionResult<List<ProjetoPoco>> GetByTipoProjetoId(int tipcod)
        {
            try
            {
                List<ProjetoPoco> listaPoco = this.servico.Consultar(pro => (pro.CodigoTipoProjeto == tipcod)).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Traz todos os registros de acordo com o código de StatusProjeto.
        /// </summary>
        /// <param name="stacod"></param>
        /// <returns></returns>
        [HttpGet("PorStatusProjeto/{stacod:int}")]
        public ActionResult<List<ProjetoPoco>> GetByStatusProjetoId(int stacod)
        {
            try
            {
                List<ProjetoPoco> listaPoco = this.servico.Consultar(pro => (pro.CodigoStatusProjeto == stacod)).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o projeto de acordo com o código informado
        /// </summary>
        /// <param name="codigo"> Informe um Código </param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<ProjetoPoco> GetById(int codigo)
        {
            try
            {
                ProjetoPoco poco = this.servico.PesquisarPorChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo registro na tabela
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ProjetoPoco> Post([FromBody] ProjetoPoco poco)
        {
            try
            {
                ProjetoPoco nova = this.servico.Inserir(poco);
                return Ok(nova);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza os dados da tabela 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ProjetoPoco> Put([FromBody] ProjetoPoco poco)
        {
            try
            {
                ProjetoPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro por codigo informado
        /// </summary>
        /// <param name="codigo"> Informe um código que deseja apagar </param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<ProjetoPoco> DeleteById(int codigo)
        {
            try
            {
                ProjetoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}