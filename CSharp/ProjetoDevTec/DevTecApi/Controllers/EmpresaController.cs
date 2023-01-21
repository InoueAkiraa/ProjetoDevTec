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
    public class EmpresaController : ControllerBase
    {
        private EmpresaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public EmpresaController(DevTecContext contexto) : base()
        {
            this.servico = new EmpresaServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela Empresa, respeitando parâmetros Take e Skip
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<EmpresaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EmpresaPoco> listaPoco = this.servico.Listar(take, skip);
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
        public ActionResult<EmpresaPoco> GetById(int chave)
        {
            try
            {
                EmpresaPoco poco = this.servico.PesquisarPorChave(chave);
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
        public ActionResult<EmpresaPoco> Post([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaPoco novoPoco = this.servico.Inserir(poco);
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
        public ActionResult<EmpresaPoco> Put([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<EmpresaPoco> Delete(int chave)
        {
            try
            {
                EmpresaPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }










        [HttpGet("envelope/")]
        public ActionResult<EnvelopeGenerico<EmpresaEnvelope>> GetAllEnvelope(int? take = null, int? skip = null)
        {
            try
            {
                List<EmpresaPoco> listaPoco = this.servico.Listar(take, skip);
                List<EmpresaEnvelope> listaEnvelope = listaPoco.Select(emp => new EmpresaEnvelope(emp)).ToList();
                foreach (var item in listaEnvelope)
                {
                    item.SetLinks();
                }
                string linkPost = "POST /empresa";
                ListEnvelope<EmpresaEnvelope> list = new ListEnvelope<EmpresaEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                return Ok(list.Etapa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("envelope/{chave:int}")]
        public ActionResult<EmpresaEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                EmpresaPoco poco = this.servico.PesquisarPorChave(chave);
                EmpresaEnvelope envelope = new EmpresaEnvelope(poco);
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