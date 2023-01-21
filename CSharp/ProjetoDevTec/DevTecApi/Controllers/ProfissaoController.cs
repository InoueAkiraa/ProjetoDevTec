using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevTec.Domain.EF;
using DevTec.Poco;
using LinqKit;
using DevTec.Service.Recursos;
using DevTec.Envelope.Motor;
using DevTec.Envelope.Modelo;

namespace DevTecApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/desenvolvimento/[controller]")]
    [ApiController]
    public class ProfissaoController : ControllerBase
    {
        private ProfissaoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ProfissaoController(DevTecContext contexto) : base()
        {
            this.servico = new ProfissaoServico(contexto);
        }

        /// <summary>
        /// Traz todos os registros da tabela Profissão respeitando parâmetros Take e Skip
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProfissaoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ProfissaoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna o registro de acordo com a chave primária
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<ProfissaoPoco> GetById(int chave)
        {
            try
            {
                ProfissaoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna o registros de acordo com a profissão informada.
        /// </summary>
        /// <param name="profissao"></param>
        /// <returns></returns>
        [HttpGet("PorProfissao/{profissao}")]
        public ActionResult<List<ProfissaoPoco>> GetById(string profissao)
        {
            try
            {
                List<ProfissaoPoco> listaPoco;
                var predicado = PredicateBuilder.New<Profissao>(true);
                predicado = predicado.And(s => s.Descricao == profissao);
                listaPoco = this.servico.Consultar(predicado);
                return Ok(listaPoco);
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
        public ActionResult<ProfissaoPoco> Post([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Profissao.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<ProfissaoPoco> Put([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente em Profissao, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<ProfissaoPoco> DeleteById(int chave)
        {
            try
            {
                ProfissaoPoco poco = this.servico.Excluir(chave);
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
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet("envelope/")]
        public ActionResult<EnvelopeGenerico<ProfissaoEnvelope>> GetAllEnvelope(int? take = null, int? skip = null)
        {
            try
            {
                List<ProfissaoPoco> listaPoco = this.servico.Listar(take, skip);

                List<ProfissaoEnvelope> listaEnvelope = listaPoco.Select(pro => new ProfissaoEnvelope(pro)).ToList();
                foreach (var item in listaEnvelope)
                {
                    item.SetLinks();
                }
                string linkPost = "POST /estado";
                ListEnvelope<ProfissaoEnvelope> list = new ListEnvelope<ProfissaoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
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
        public ActionResult<ProfissaoEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                ProfissaoPoco poco = this.servico.PesquisarPorChave(chave);
                ProfissaoEnvelope envelope = new ProfissaoEnvelope(poco);
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
