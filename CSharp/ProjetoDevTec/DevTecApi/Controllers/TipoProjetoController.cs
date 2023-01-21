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
    public class TipoProjetoController : ControllerBase
    {
        private TipoProjetoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public TipoProjetoController(DevTecContext contexto) : base()
        {
            this.servico = new TipoProjetoServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela TipoProjeto, respeitando parâmetros Take e Skip
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoProjetoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoProjetoPoco> listaPoco = this.servico.Listar(take, skip);
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
        public ActionResult<TipoProjetoPoco> GetById(int chave)
        {
            try
            {
                TipoProjetoPoco poco = this.servico.PesquisarPorChave(chave);
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
        public ActionResult<TipoProjetoPoco> Post([FromBody] TipoProjetoPoco poco)
        {
            try
            {
                TipoProjetoPoco novoPoco = this.servico.Inserir(poco);
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
        public ActionResult<TipoProjetoPoco> Put([FromBody] TipoProjetoPoco poco)
        {
            try
            {
                TipoProjetoPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<TipoProjetoPoco> Delete(int chave)
        {
            try
            {
                TipoProjetoPoco delPoco = this.servico.Excluir(chave);
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
        public ActionResult<EnvelopeGenerico<TipoProjetoEnvelope>> GetAllEnvelope(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoProjetoPoco> listaPoco = this.servico.Listar(take, skip);
                List<TipoProjetoEnvelope> listaEnvelope = listaPoco.Select(tpr => new TipoProjetoEnvelope(tpr)).ToList();
                foreach (var item in listaEnvelope)
                {
                    item.SetLinks();
                }
                string linkPost = "POST /tipoprojeto";
                ListEnvelope<TipoProjetoEnvelope> list = new ListEnvelope<TipoProjetoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
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
        public ActionResult<TipoProjetoEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                TipoProjetoPoco poco = this.servico.PesquisarPorChave(chave);
                TipoProjetoEnvelope envelope = new TipoProjetoEnvelope(poco);
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