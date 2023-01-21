using DevTec.Domain.EF;
using DevTec.Poco;
using DevTec.Service.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LinqKit;
using System.Linq;
using DevTec.Envelope.Motor;
using DevTec.Envelope.Modelo;

namespace DevTecApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/desenvolvimento/[controller]")]
    [ApiController]
    public class TipoPessoaController : ControllerBase
    {
        private TipoPessoaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public TipoPessoaController(DevTecContext contexto) : base()
        {
            this.servico = new TipoPessoaServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela TipoPessoa, respeitando parâmetros Take e Skip
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoPessoaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoPessoaPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Retorna o registro de acordo com o código da chave primária informada.
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<TipoPessoaPoco> GetById(int chave)
        {
            try
            {
                TipoPessoaPoco poco = this.servico.PesquisarPorChave(chave);
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
        public ActionResult<TipoPessoaPoco> Post([FromBody] TipoPessoaPoco poco)
        {
            try
            {
                TipoPessoaPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a alteração de um registro existente.
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<TipoPessoaPoco> Put([FromBody] TipoPessoaPoco poco)
        {
            try
            {
                TipoPessoaPoco alteradaPoco = this.servico.Alterar(poco);
                return Ok(alteradaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusao de um registro existente de acordo com a chave primária informada.
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<TipoPessoaPoco> Delete(int chave)
        {
            try
            {
                TipoPessoaPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }












        /// <summary>
        /// 
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet("envelope/")]
        public ActionResult<EnvelopeGenerico<TipoPessoaEnvelope>> GetAllEnvelope(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoPessoaPoco> listaPoco = this.servico.Listar(take, skip);

                List<TipoPessoaEnvelope> listaEnvelope = listaPoco.Select(tpe => new TipoPessoaEnvelope(tpe)).ToList();
                foreach (var item in listaEnvelope)
                {
                    item.SetLinks();
                }
                string linkPost = "POST /tipopessoa";
                ListEnvelope<TipoPessoaEnvelope> list = new ListEnvelope<TipoPessoaEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                return Ok(list.Etapa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("envelope/{chave:int}")]
        public ActionResult<TipoPessoaEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                TipoPessoaPoco poco = this.servico.PesquisarPorChave(chave);
                TipoPessoaEnvelope envelope = new TipoPessoaEnvelope(poco);
                envelope.SetLinks();
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}