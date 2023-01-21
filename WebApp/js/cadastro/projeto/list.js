$(function(){
  carregar(valor);
});

function carregar(valor){
  var caminhoDetalhadoEmpresa = caminho + "/PorEmpresa/" + valor;

  // var caminhoDetalhadoTipoProjeto = caminho + "/PorTipoProjeto/" + valor;

  $.get(caminhoDetalhadoEmpresa, function(data, status){
      if (data == 0){
        alert("Erro ao obter os dados.")
        return;
      }
      else{
        $("#tblDados tbody").empty();
        for (let index = 0; index < data.length; index++) {
          const projeto = data[index];
          
          console.log(projeto);

          var codigoProjeto = projeto.codigoProjeto;
          var nome = projeto.nome;
          var descricao = projeto.descricao;
          var precoListado = projeto.precoListado;

          var linha = '';
          linha += "<tr>";
          linha += "  <td class='table-active text-center'>";
          linha += "    <button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoProjeto +");'> ";
          linha += "      <img src='/img/att.png''width=35 height=35'>";
          linha += "    </button>";
          linha += "  </td>";
          linha += "  <td class='table-active text-center'>" + codigoProjeto + "</td>";
          linha += "  <td class='table-active text-center'>" + nome + "</td>";
          linha += "  <td class='table-active text-center'>" + descricao + "</td>";
          linha += "  <td class='table-active text-center'>" + precoListado + "</td>";
          linha += "  <td class='table-active text-center'>";
          linha += "    <button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoProjeto +");'>Alterar</button>";
          linha += "  </td>";
          linha += "  <td class='table-active text-center'>";
          linha += "    <button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoProjeto +");'>Excluir</button>";
          linha += "  </td>";
          linha += "</tr>";
          
          $("#tblDados tbody").append(linha);
        }
      }

  });
}

function exibirAtual(codigo){
  localStorage.setItem("projetoAcao", JSON.stringify(0));
  localStorage.setItem("codigoProjetoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("projetoAcao", JSON.stringify(1));
  window.location.href = "detail.html";
}

function alterarAtual(codigo){
  localStorage.setItem("projetoAcao", JSON.stringify(2));
  localStorage.setItem("codigoProjetoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("projetoAcao", JSON.stringify(3));
  localStorage.setItem("codigoProjetoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

var empresas = [];
var tipoProjeto = [];
var statusProjeto = [];

$(function(){
  carregarEmpresa();
  $("#ddlEmpresas").change(function(){
    var valor = $(this).children("option:selected").val();
    carregar(valor);
  });

  carregarTipoProjeto();
  $("#ddlTipoProjeto").change(function(){
    var valor = $(this).children("option:selected").val();
    // carregar(valor);
  });

  carregarStatusProjeto();
  $("#ddlStatusProjeto").change(function(){
    var valor = $(this).children("option:selected").val();
    // carregar(valor);
  });
});

function carregarEmpresa(){
  var caminhoEmpresa = servidor + "/" + "Empresa";
  $.get(caminhoEmpresa, function(data){
    for (let index = 0; index < data.length; index++) {
      const empresa = data[index];
    
      console.log(empresa);

      $("#ddlEmpresas").append(
        $('<option></option>').val(empresa.codigoEmpresa).html(empresa.descricao));
    }
  });
}

function carregarTipoProjeto(){
  var caminhoTipoProjeto = servidor + "/" + "TipoProjeto";
  $.get(caminhoTipoProjeto, function(data){
    for (let index = 0; index < data.length; index++) {
      const tipoProjeto = data[index];
    
      console.log(tipoProjeto);

      $("#ddlTipoProjeto").append(
        $('<option></option>').val(tipoProjeto.codigoTipoProjeto).html(tipoProjeto.descricao));
    }
  });
}

function carregarStatusProjeto(){
  var caminhoStatusProjeto = servidor + "/" + "StatusProjeto";
  $.get(caminhoStatusProjeto, function(data){
    for (let index = 0; index < data.length; index++) {
      const statusProjeto = data[index];
    
      console.log(statusProjeto);

      $("#ddlStatusProjeto").append(
        $('<option></option>').val(statusProjeto.codigoStatusProjeto).html(statusProjeto.descricao));
    }
  });
}