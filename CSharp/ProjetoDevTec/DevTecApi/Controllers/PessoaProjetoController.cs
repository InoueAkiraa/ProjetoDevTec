using DevTec.Domain.EF;
using DevTec.Poco;
using DevTec.Service.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevTecApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/desenvolvimento/[controller]")]
    [ApiController]
    public class PessoaProjetoController : ControllerBase
    {
        private PessoaProjetoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public PessoaProjetoController(DevTecContext contexto) : base()
        {
            this.servico = new PessoaProjetoServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela PessoaProjeto
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PessoaProjetoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<PessoaProjetoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela PessoaProjeto buscando por Pessoa
        /// </summary>
        /// <param name="pesid"></param>
        /// <returns></returns>
        [HttpGet("PorPessoa/{pesid:int}")]
        public ActionResult<List<PessoaProjetoPoco>> GetByPessoa(int pesid)
        {
            try
            {
                List<PessoaProjetoPoco> listaPoco = this.servico.Consultar(pes => pes.CodigoPessoa == pesid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela PessoaProjeto buscando por Projeto
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        [HttpGet("PorProjeto/{proid:int}")]
        public ActionResult<List<PessoaProjetoPoco>> GetByAtendente(int proid)
        {
            try
            {
                List<PessoaProjetoPoco> listaPoco = this.servico.Consultar(pro => pro.CodigoProjeto == proid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna o registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<PessoaProjetoPoco> GetById(int chave)
        {
            try
            {
                PessoaProjetoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a criação de um novo registro
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PessoaProjetoPoco> Post([FromBody] PessoaProjetoPoco poco)
        {
            try
            {
                PessoaProjetoPoco novaPoco = this.servico.Inserir(poco);
                return Ok(novaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a alteração de um registro
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<PessoaProjetoPoco> Put([FromBody] PessoaProjetoPoco poco)
        {
            try
            {
                PessoaProjetoPoco alteradaPoco = this.servico.Alterar(poco);
                return Ok(alteradaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão do registro de acordo com o ID.
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<PessoaProjetoPoco> Delete(int chave)
        {
            try
            {
                PessoaProjetoPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}