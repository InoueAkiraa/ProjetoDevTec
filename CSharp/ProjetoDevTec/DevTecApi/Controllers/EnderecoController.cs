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
    public class EnderecoController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        public EnderecoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EnderecoController(DevTecContext context) : base()
        {
            this.servico = new EnderecoServico(context);
        }

        /// <summary>
        /// Lista todos os registros de Endereço por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<EnderecoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EnderecoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Endereço por código Cidade.
        /// </summary>
        /// <param name="cidadecod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorCidade/{cidadecod:int}")]
        public ActionResult<List<EnderecoPoco>> GetByCidade(int cidadecod)
        {
            try
            {
                List<EnderecoPoco> listaPoco = this.servico.Consultar(end => (end.CodigoCidade == cidadecod)).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Edereco.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<EnderecoPoco> GetById(int chave)
        {
            try
            {
                EnderecoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Endereco.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<EnderecoPoco> Post([FromBody] EnderecoPoco poco)
        {
            try
            {
                EnderecoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Endereco.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<EnderecoPoco> Put([FromBody] EnderecoPoco poco)
        {
            try
            {
                EnderecoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente em Endereco, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<EnderecoPoco> DeleteById(int chave)
        {
            try
            {
                EnderecoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}