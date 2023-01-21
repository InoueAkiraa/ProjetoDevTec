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
            const tipoPessoa = data[index];
            
            console.log(tipoPessoa);

            var codigoTipoPessoa = tipoPessoa.codigoTipoPessoa;
            var descricao = tipoPessoa.descricao;
            var siglaTipoPessoa = tipoPessoa.siglaTipoPessoa;

            var linha = '';
            linha += "<tr>";
            linha += "  <td class='table-active text-center'>";
            linha += "    <button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoTipoPessoa +");'> ";
            linha += "      <img src='/img/att.png''width=35 height=35'>";
            linha += "    </button>";
            linha += "  </td>";
            linha += "  <td class='table-active text-center'>" + codigoTipoPessoa + "</td>";
            linha += "  <td class='table-active text-center'>" + descricao + "</td>";
            linha += "  <td class='table-active text-center'>" + siglaTipoPessoa + "</td>";
            linha += "  <td class='table-active text-center'>";
            linha += "    <button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoTipoPessoa +");'>Alterar</button>";
            linha += "  </td>";
            linha += "  <td class='table-active text-center'>";
            linha += "    <button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoTipoPessoa +");'>Excluir</button>";
            linha += "  </td>";
            linha += "</tr>";
            $("#tblDados tbody").append(linha);
          }
        }

    });
}

function exibirAtual(codigo){
  localStorage.setItem("tipoPessoaAcao", JSON.stringify(0));
  localStorage.setItem("codigoTipoPessoaSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("tipoPessoaAcao", JSON.stringify(1));
  window.location.href = "detail.html";
}

function alterarAtual(codigo){
  localStorage.setItem("tipoPessoaAcao", JSON.stringify(2));
  localStorage.setItem("codigoTipoPessoaSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("tipoPessoaAcao", JSON.stringify(3));
  localStorage.setItem("codigoTipoPessoaSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}