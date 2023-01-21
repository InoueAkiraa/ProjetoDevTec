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
            const statusprojeto = data[index];
            
            console.log(statusprojeto);

            var codigoStatusProjeto = statusprojeto.codigoStatusProjeto;
            var descricao = statusprojeto.descricao;
            var siglaStatusProjeto = statusprojeto.siglaStatusProjeto;

            var linha = '';
            linha += "<tr>";
            linha += "<td class='table-active text-center'>";
            linha += "<button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoStatusProjeto +");'>";
            linha += "<img src='/img/att.png''width=35 height=35'>";
            linha += "</button>";
            linha += "</td>";
            linha += "<td class='table-active text-center'>" + codigoStatusProjeto + "</td>";
            linha += "<td class='table-active text-center'>" + descricao + "</td>";
            linha += "<td class='table-active text-center'>" + siglaStatusProjeto + "</td>";
            linha += "<td class='table-active text-center'>";
            linha += "<button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoStatusProjeto +");'>Alterar</button>";
            linha += "</td>";
            linha += "<td class='table-active text-center'>";
            linha += "<button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoStatusProjeto +");'>Excluir</button>";
            linha += "</td>";
            
            $("#tblDados tbody").append(linha);
          }
        }

    });
}

function exibirAtual(codigo){
  localStorage.setItem("statusProjetoAcao",JSON.stringify(0));
    localStorage.setItem("codigoStatusProjetoSelecionado",JSON.stringify(codigo));
    window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("statusProjetoAcao",JSON.stringify(1));
  window.location.href = "detail.html";
}


function alterarAtual(codigo){
  localStorage.setItem("statusProjetoAcao",JSON.stringify(2));
  localStorage.setItem("codigoStatusProjetoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("statusProjetoAcao",JSON.stringify(3));
  localStorage.setItem("codigoStatusProjetoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}