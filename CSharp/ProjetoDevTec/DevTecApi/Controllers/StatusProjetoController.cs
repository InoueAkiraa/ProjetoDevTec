using DevTec.Domain.EF;
using DevTec.Poco;
using DevTec.Service.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LinqKit;
using DevTec.Envelope.Motor;
using DevTec.Envelope.Modelo;

namespace DevTecApi.Controllers
{

    /// <summary>
    ///
    /// </summary>
    [Route("api/desenvolvimento/[controller]")]
    [ApiController]
    public class StatusProjetoController : ControllerBase
    {
        private StatusProjetoServico servico;

        /// <summary>
        ///
        /// </summary>
        /// <param name="contexto"></param>
        public StatusProjetoController(DevTecContext contexto) : base()
        {
            this.servico = new StatusProjetoServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela StatusProjeto, respeitando parâmetros Take e Skip
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StatusProjetoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<StatusProjetoPoco> listaPoco = this.servico.Listar(take, skip);
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
        public ActionResult<StatusProjetoPoco> GetById(int chave)
        {
            try
            {
                StatusProjetoPoco poco = this.servico.PesquisarPorChave(chave);
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
        public ActionResult<StatusProjetoPoco> Post([FromBody] StatusProjetoPoco poco)
        {
            try
            {
                StatusProjetoPoco novoPoco = this.servico.Inserir(poco);
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
        public ActionResult<StatusProjetoPoco> Put([FromBody] StatusProjetoPoco poco)
        {
            try
            {
                StatusProjetoPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<StatusProjetoPoco> Delete(int chave)
        {
            try
            {
                StatusProjetoPoco delPoco = this.servico.Excluir(chave);
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
        public ActionResult<EnvelopeGenerico<StatusProjetoEnvelope>> GetAllEnvelope(int? take = null, int? skip = null)
        {
            try
            {
                List<StatusProjetoPoco> listaPoco = this.servico.Listar(take, skip);

                List<StatusProjetoEnvelope> listaEnvelope = listaPoco.Select(spr => new StatusProjetoEnvelope(spr)).ToList();
                foreach (var item in listaEnvelope)
                {
                    item.SetLinks();
                }
                string linkPost = "POST /statusprojeto";
                ListEnvelope<StatusProjetoEnvelope> list = new ListEnvelope<StatusProjetoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
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
        public ActionResult<StatusProjetoEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                StatusProjetoPoco poco = this.servico.PesquisarPorChave(chave);
                StatusProjetoEnvelope envelope = new StatusProjetoEnvelope(poco);
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