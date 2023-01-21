var count = 0;
$(function(){
  carregarPessoa();
  $("#ddlSigla").change(function(){
      var sigla = $(this).children("option:selected").val();
      var limite = $("#ddlTakeSkip").children("option:selected").val();
      if (limite != 0){
        var caminhoTakeSkip = caminho + "/PorSiglaTakeSkip/" + sigla;
        carregarCount(sigla);
        paginacao(caminhoTakeSkip, count, limite);
        console.log(listaUrl);
        carregar(sigla, listaUrl[0]);
        carregarLinkPaginacao(sigla);
      }
      else{
        var caminhoTakeSkip = caminho + "/PorSiglaTakeSkip/" + sigla;
        carregarCount(sigla);
        paginacao(caminhoTakeSkip, count, 100);
        console.log(listaUrl);
        carregar(sigla, listaUrl[0]);
        carregarLinkPaginacao(sigla);
      }
  });

  $("#ddlTakeSkip").change(function(){
    var limite = $(this).children("option:selected").val();
    var sigla = $("#ddlSigla").children("option:selected").val();
    if (sigla != 0){
      var caminhoTakeSkip = caminho + "/PorSiglaTakeSkip/" + sigla;
      carregarCount(sigla);
      paginacao(caminhoTakeSkip, count, limite);
      console.log(listaUrl);
      carregar(sigla, listaUrl[0]);
      carregarLinkPaginacao(sigla);
    }
  })
});

// OK
//  PEGAR VALOR DO DROPDOWN PARA 1° CARREGAMENTO
//  CRIAR EVENTO CHANGE PARA O DDL (DROPDOWN) COM LIMITE
//  ALTERAR A FUNCTION Paginacao() para aceitar novo parámetro de limite

// A FAZER
//  TODO LIST
//  DIMINUIR O RANGE DOS BOTÕES (tá grande e saindo da página)

function carregar(sigla, url){
  if (sigla != undefined){
    var caminhoDetalhado = url; //caminho + "/PorSiglaPessoa/"+ sigla;
      $.get(caminhoDetalhado, function(data, status){
          if (data == 0){
            alert("Erro ao obter os dados.")
            return;
          }
          else{
            $("#tblDados tbody").empty();
            for (let index = 0; index < data.length; index++) {
              const pessoa = data[index];

              // console.log(pessoa);

              var codigoPessoa = pessoa.codigoPessoa;
              var nome = pessoa.nome;
              var sobrenome = pessoa.sobrenome;
              var email = pessoa.email;
              var telefone = pessoa.telefone;

              var linha = '';
              linha += "<tr>";
              linha +=  "<td class='table-active text-center'>";
              linha +=    "<button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoPessoa +");'>";
              linha +=      "<img src='/img/att.png''width=35 height=35'>";
              linha +=    "</button>";
              linha +=  "</td>";
              linha += "<td class='table-active text-center'>" + codigoPessoa + "</td>";
              linha += "<td class='table-active text-center'>" + nome + "</td>";
              linha += "<td class='table-active text-center'>" + sobrenome + "</td>";
              linha += "<td class='table-active text-center'>" + email + "</td>";
              linha += "<td class='table-active text-center'>" + telefone + "</td>";
              linha += "<td class='table-active text-center'>";
              linha +=    "<button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoPessoa +");'>Alterar</button>";
              linha +=    "</td>";
              linha += "<td class='table-active text-center'>";
              linha +=    "<button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoPessoa +");'>Excluir</button>";
              linha +=    "</td>";
              linha += "</tr>"; 
              $("#tblDados tbody").append(linha);
            }
          }
      });
  }
}

function exibirAtual(codigo){
  localStorage.setItem("pessoaAcao",JSON.stringify(0));
  localStorage.setItem("codigoPessoaSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("pessoaAcao",JSON.stringify(1));
  window.location.href = "detail.html";
}


function alterarAtual(codigo){
  localStorage.setItem("pessoaAcao",JSON.stringify(2));
  localStorage.setItem("codigoPessoaSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("pessoaAcao",JSON.stringify(3));
  localStorage.setItem("codigoPessoaSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function carregarPessoa(){
  var caminhoPessoa  = servidor + "/" + "TipoPessoa";
  $.get(caminhoPessoa, function(data){

        for (let index = 0; index < data.length; index++) {
          const pessoa = data[index];
          // console.log(pessoa);
          $("#ddlSigla").append(
            $('<option></option>').val(pessoa.siglaTipoPessoa).html(pessoa.siglaTipoPessoa)
        );
        }     
  });
}

function carregarCount(sigla){
  var caminhoCount = caminho + "/PorCount/" + sigla;
  $.ajax({
    url: caminhoCount,
    type: "get",
    dataType: "json",
    contentType: "application/json",
    data: null,
    async: false,
    success: function(data, status, xhr){
        count = data;
    },
    error: function(xhr, status, errorThrown){
        alert("Erro ao gravar os dados. " + status);
        return;
    }
  });
}

function carregarLinkPaginacao(sigla){
  $("#tblPaginacao tbody tr").empty();
  for (let index = 0; index < listaUrl.length; index++) {
    const url = listaUrl[index];
    var linha = '';
    linha +=  "<td class='table-light text-center'>";
    linha +=    "<button id='btn' class='border-light border-0 btn-light btn-outline-white' onclick='carregar(\""+ sigla +"\",\""+ url +"\");'>";
    linha +=    + (index+1) +"</button>";
    linha +=  "</td>";
    $("#tblPaginacao tbody tr").append(linha);
  }
}