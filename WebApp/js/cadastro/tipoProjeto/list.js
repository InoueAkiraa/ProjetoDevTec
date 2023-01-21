$(function(){
    carregar();
});

function carregar(){
    $.get(caminho, function(data, status){
        if (data == 0){
          alert("Erro ao obter os dados.")
          return;
        }
        else{
          for (let index = 0; index < data.length; index++) {
            const tipoProjeto = data[index];
            
            console.log(tipoProjeto);

            var codigoTipoProjeto = tipoProjeto.codigoTipoProjeto;
            var descricao = tipoProjeto.descricao;
            var linguagem = tipoProjeto.linguagem;

            var linha = '';
            linha += "<tr>";
            linha +=  "<td class='table-active text-center'>";
            linha +=    "<button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoTipoProjeto +");'>";
            linha +=      "<img src='/img/att.png''width=35 height=35'>";
            linha +=    "</button>";
            linha +=  "</td>";
            linha += "<td class='table-active text-center'>" + codigoTipoProjeto + "</td>";
            linha += "<td class='table-active text-center'>" + descricao + "</td>";
            linha += "<td class='table-active text-center'>" + linguagem + "</td>";
            linha += "<td class='table-active text-center'>";
            linha +=    "<button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoTipoProjeto +");'>Alterar</button>";
            linha +=    "</td>";
            linha += "<td class='table-active text-center'>";
            linha +=    "<button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoTipoProjeto +");'>Excluir</button>";
            linha +=    "</td>";
            linha += "</tr>"; 

            $("#tblDados tbody").append(linha);
          }
        }

    });
}

function exibirAtual(codigo){
    localStorage.setItem("tipoProjetoAcao", JSON.stringify(0));
    localStorage.setItem("codigoTipoProjetoSelecionado",JSON.stringify(codigo));
    window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("tipoProjetoAcao", JSON.stringify(1));
  window.location.href = "detail.html";
}

function alterarAtual(codigo){
  localStorage.setItem("tipoProjetoAcao", JSON.stringify(2));
  localStorage.setItem("codigoTipoProjetoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("tipoProjetoAcao", JSON.stringify(3));
  localStorage.setItem("codigoTipoProjetoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}