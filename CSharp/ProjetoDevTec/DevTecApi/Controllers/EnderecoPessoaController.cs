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
    public class EnderecoPessoaController : ControllerBase
    {
        private EnderecoPessoaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public EnderecoPessoaController(DevTecContext contexto) : base()
        {
            this.servico = new EnderecoPessoaServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela EnderecoPessoa
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<EnderecoPessoaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EnderecoPessoaPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela EnderecoPessoa buscando por Endereco
        /// </summary>
        /// <param name="endid"></param>
        /// <returns></returns>
        [HttpGet("PorEndereco/{endid:int}")]
        public ActionResult<List<EnderecoPessoaPoco>> GetByEndereco(int endid)
        {
            try
            {
                List<EnderecoPessoaPoco> listaPoco = this.servico.Consultar(end => end.CodigoEndereco == endid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela EnderecoPessoa buscando por Pessoa
        /// </summary>
        /// <param name="pesid"></param>
        /// <returns></returns>
        [HttpGet("PorPessoa/{pesid:int}")]
        public ActionResult<List<EnderecoPessoaPoco>> GetByPessoa(int pesid)
        {
            try
            {
                List<EnderecoPessoaPoco> listaPoco = this.servico.Consultar(pes => pes.CodigoPessoa == pesid).ToList();
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
        public ActionResult<EnderecoPessoaPoco> GetById(int chave)
        {
            try
            {
                EnderecoPessoaPoco poco = this.servico.PesquisarPorChave(chave);
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
        public ActionResult<EnderecoPessoaPoco> Post([FromBody] EnderecoPessoaPoco poco)
        {
            try
            {
                EnderecoPessoaPoco novaPoco = this.servico.Inserir(poco);
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
        public ActionResult<EnderecoPessoaPoco> Put([FromBody] EnderecoPessoaPoco poco)
        {
            try
            {
                EnderecoPessoaPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<EnderecoPessoaPoco> Delete(int chave)
        {
            try
            {
                EnderecoPessoaPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}