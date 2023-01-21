using DevTec.Domain.EF;
using DevTec.Envelope.Modelo;
using DevTec.Envelope.Motor;
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
    public class EstadoController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        public EstadoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EstadoController(DevTecContext context) : base()
        {
            this.servico = new EstadoServico(context);
        }

        /// <summary>
        /// Lista todos os registros de Estado por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<EstadoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Estado.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<EstadoPoco> GetById(int chave)
        {
            try
            {
                EstadoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Estado.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<EstadoPoco> Post([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Estado.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<EstadoPoco> Put([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente em Estado, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<EstadoPoco> DeleteById(int chave)
        {
            try
            {
                EstadoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }















        /// <summary>
        /// 
        /// </summary>
        /// <param name="limite"></param>
        /// <param name="salto"></param>
        /// <returns></returns>
        [HttpGet("envelope/")]
        public ActionResult<EnvelopeGenerico<EstadoEnvelope>> GetAllEnvelope(int? limite = null, int? salto = null)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Listar(limite, salto);
                List<EstadoEnvelope> listaEnvelope = listaPoco.Select(est => new EstadoEnvelope(est)).ToList();
                listaEnvelope.ForEach(item => item.SetLinks());
                
                string linkPost = "POST /estado";

                ListEnvelope<EstadoEnvelope> list;

                if (salto == null)
                {
                    list = new ListEnvelope<EstadoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                }
                else
                {
                    var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}");
                    string urlServidor = location.AbsoluteUri;
                    list = new ListEnvelope<EstadoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0", urlServidor, salto, limite);
                }
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
        public ActionResult<EstadoEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                EstadoPoco poco = this.servico.PesquisarPorChave(chave);
                EstadoEnvelope envelope = new EstadoEnvelope(poco);
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