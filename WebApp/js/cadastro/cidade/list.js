$(function(){
  carregar(valor);
});

function carregar(valor){
    var caminhoDetalhado = caminho + "/PorEstado/"+ valor;
    $.get(caminhoDetalhado, function(data, status){
        if (data == 0){
          alert("Erro ao obter os dados.")
          return;
        }
        else{
          $("#tblDados tbody").empty();
          for (let index = 0; index < data.length; index++) {
            const cidade = data[index];

            console.log(cidade);


            var codigoCidade = cidade.codigoCidade;
            var nome = cidade.nome;
            var codigoIBGE7 = cidade.codigoIBGE7;
            var codigoEstado = cidade.codigoEstado;

            var linha = '';
            linha += "<tr>";
            linha += "    <td class='table-active text-center'>";
            linha += "      <button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoCidade +");'> ";
            linha += "        <img src='/img/att.png''width=35 height=35'>";
            linha += "      </button>";
            linha += "    </td>";
            linha += "  <td class='table-active text-center'>" + codigoCidade + "</td>";
            linha += "  <td class='table-active text-center'>" + nome + "</td>";
            linha += "  <td class='table-active text-center'>" + codigoIBGE7 + "</td>";
            linha += "  <td class='table-active text-center'>" + codigoEstado + "</td>";
            linha += "  <td class='table-active text-center'>";
            linha += "    <button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoCidade +");'> Alterar</button>";
            linha += "  </td>";
            linha += "  <td class='table-active text-center'>";
            linha += "  <button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoCidade +");'> Excluir </button>";
            linha += "  </td>";
            linha += "</tr>";
              $("#tblDados tbody").append(linha);
          }
        }

    });
}

function exibirAtual(codigo){
  localStorage.setItem("cidadeAcao", JSON.stringify(0));
  localStorage.setItem("codigoCidadeSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
localStorage.setItem("cidadeAcao", JSON.stringify(1));
window.location.href = "detail.html"
}

function alterarAtual(codigo){
localStorage.setItem("cidadeAcao", JSON.stringify(2));
localStorage.setItem("codigoCidadeSelecionado",JSON.stringify(codigo));
window.location.href = "detail.html";
}

function excluirAtual(codigo){
localStorage.setItem("cidadeAcao", JSON.stringify(3));
localStorage.setItem("codigoCidadeSelecionado",JSON.stringify(codigo));
window.location.href = "detail.html";
}


var estados = [];

$(function(){
  carregarEstado();
  $("#ddlEstados").change(function(){
      var valor = $(this).children("option:selected").val();
      carregar(valor);
  });
});

// function carregarEstados(){
//   for (let index = 0; index < estados.length; index++) {
//       const estado = estados[index];
//       $("#ddlEstados").append(
//           $('<option></option>').val(estado.id).html(estado.nome)
//       );
//   }
// }

function carregarEstado(){
  var caminhoEstado  = servidor + "/" + "Estado";
  $.get(caminhoEstado, function(data){

        for (let index = 0; index < data.length; index++) {
          const estado = data[index];
          
          console.log(estado);

          $("#ddlEstados").append(
            $('<option></option>').val(estado.codigoEstado).html(estado.nome)
        );
        }     

  });
}