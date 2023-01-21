using DevTec.Domain.EF;
using DevTec.Poco;
using DevTec.Service.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LinqKit;

namespace DevTecApi.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("api/desenvolvimento/[controller]")]
public class PessoaController : ControllerBase
{
    private PessoaServico servico;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public PessoaController(DevTecContext context) : base()
    {
        this.servico = new PessoaServico(context);
    }

    /// <summary>
    /// Lista todos os registros de Pessoa por Paginação.
    /// </summary>
    /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
    /// <param name="skip"> Quantos registros serão retornados. </param>
    /// <returns> Todos os registros. </returns>
    [HttpGet]
    public ActionResult<List<PessoaPoco>> GetAll(int? take = null, int? skip = null)
    {
        try
        {
            List<PessoaPoco> listaPoco = this.servico.Listar(take, skip);
            return Ok(listaPoco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="porSigla"></param>
    /// <returns></returns>
    [HttpGet("PorCount/{porSigla}")]
    public ActionResult<PessoaPoco> GetByCount(string porSigla)
    {
        try
        {
            List<PessoaPoco> listaPoco;
            var predicado = PredicateBuilder.New<Pessoa>(true);
            predicado = predicado.And(s => s.SiglaTipoPessoa == porSigla);
            listaPoco = this.servico.Consultar(predicado);
            return Ok(listaPoco.Count());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }


    /// <summary>
    /// Lista os registro de Pessoa usando a chave de TipoPessoa.
    /// </summary>
    /// <param name="tipid">Chave de pesquisa.</param>
    /// <returns>Registro localizado.</returns>
    [HttpGet("PorTipoPessoa/{tipid:int}")]
    public ActionResult<PessoaPoco> GetByTipoPessoa(int tipid)
    {
        try
        {
            List<PessoaPoco> listPoco = this.servico.Consultar(s => (s.CodigoTipoPessoa == tipid));
            return Ok(listPoco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Lista os registro de Pessoa por Sigla Pessoa.
    /// </summary>
    /// /// <param name="porSigla">Chave de pesquisa.</param>
    /// <returns>Registro localizado.</returns>
    [HttpGet("PorSiglaPessoa/{porSigla}")]
    public ActionResult<PessoaPoco> GetBySigla(string porSigla)
    {
        try
        {
            List<PessoaPoco> listaPoco;
            var predicado = PredicateBuilder.New<Pessoa>(true);
            predicado = predicado.And(s => s.SiglaTipoPessoa == porSigla);
            listaPoco = this.servico.Consultar(predicado);
            return Ok(listaPoco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Retorna os tipos de usuarios com paginação
    /// </summary>
    /// <param name="porSigla"></param>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    [HttpGet("PorSiglaTakeSkip/{porSigla}")]
    public ActionResult<PessoaPoco> GetBySiglaTakeSkip(string porSigla, int? take = null, int? skip = null)
    {
        try
        {
            List<PessoaPoco> listaPoco;
            var predicado = PredicateBuilder.New<Pessoa>(true);
            if (take == null)
                {
                    if (skip != null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.SiglaTipoPessoa == porSigla);
                        listaPoco = this.servico.Consultar(predicado);
                        return Ok(listaPoco);
                    }
                }
                else
                {
                    if (skip == null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.SiglaTipoPessoa == porSigla);
                        listaPoco = this.servico.Vasculhar(take, skip, predicado);
                        return Ok(listaPoco);
                    }
                }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    ///  Lista os registro usando a chave de Pessoa.
    /// </summary>
    /// <param name="chave"> Chave de pesquisa. </param>
    /// <returns> Registro localizado. </returns>
    [HttpGet("{chave:int}")]
    public ActionResult<PessoaPoco> GetById(int chave)
    {
        try
        {
            PessoaPoco poco = this.servico.PesquisarPorChave(chave);
            return Ok(poco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Inclui um novo dado na tabela Pessoa.
    /// </summary>
    /// <param name="poco"> Dados que será incluido. </param>
    /// <returns> Dados incluido. </returns>
    [HttpPost]
    public ActionResult<PessoaPoco> Post([FromBody] PessoaPoco poco)
    {
        try
        {
            PessoaPoco novoPoco = this.servico.Inserir(poco);
            return Ok(novoPoco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Altera um dado existente na tabela Pessoa.
    /// </summary>
    /// <param name="poco"> Altera o dado selecionado. </param>
    /// <returns> Altera o dado selecionado. </returns>
    [HttpPut]
    public ActionResult<PessoaPoco> Put([FromBody] PessoaPoco poco)
    {
        try
        {
            PessoaPoco novoPoco = this.servico.Alterar(poco);
            return Ok(novoPoco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Exclui um registro existente em Pessoa, utilizando um id.
    /// </summary>
    /// <param name="chave"> Chave para localização. </param>
    /// <returns> Dado excluido por Id. </returns>
    [HttpDelete("{chave:int}")]
    public ActionResult<PessoaPoco> DeleteById(int chave)
    {
        try
        {
            PessoaPoco poco = this.servico.Excluir(chave);
            return Ok(poco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}
