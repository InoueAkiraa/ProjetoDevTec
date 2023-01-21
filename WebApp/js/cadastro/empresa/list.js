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
            const empresa = data[index];
            
            console.log(empresa);

            var codigoEmpresa = empresa.codigoEmpresa;
            var descricao = empresa.descricao;
            var cnpj = empresa.cnpj;
            var razaoSocial = empresa.razaoSocial;
            
            var linha = '';
            linha += "<tr>";
            linha += "  <td class='table-active text-center'>";
            linha += "    <button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoEmpresa +");'> ";
            linha += "      <img src='/img/att.png''width=35 height=35'>";
            linha += "   </button>";
            linha += "  </td>";
            linha += "  <td class='table-active text-center'>" + codigoEmpresa + "</td>";
            linha += "  <td class='table-active text-center'>" + descricao + "</td>";
            linha += "  <td class='table-active text-center'>" + cnpj + "</td>";
            linha += "  <td class='table-active text-center'>" + razaoSocial + "</td>";
            linha += "  <td class='table-active text-center'>";
            linha += "   <button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoEmpresa +");'>Alterar</button>";
            linha += "  </td>";
            linha += "  <td class='table-active text-center'>";
            linha += "    <button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoEmpresa +");'>Excluir</button>";
            linha += "  </td>";
            linha += "</tr>";
            
            $("#tblDados tbody").append(linha);
          }
        }

    });
}

function exibirAtual(codigo){
  localStorage.setItem("empresaAcao", JSON.stringify(0));
    localStorage.setItem("codigoEmpresaSelecionado",JSON.stringify(codigo));
    window.location.href = "detail.html";
}

function cadastrarNovo(){
localStorage.setItem("empresaAcao", JSON.stringify(1));
window.location.href = "detail.html";
//empresaAcao = 0 => exibir
//empresaAcao = 1 => cadastrar
//empresaAcao = 2 => alterar
//empresaAcao = 3 => excluir
}

function alterarAtual(codigo){
  localStorage.setItem("empresaAcao", JSON.stringify(2));
    localStorage.setItem("codigoEmpresaSelecionado",JSON.stringify(codigo));
    window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("empresaAcao", JSON.stringify(3));
    localStorage.setItem("codigoEmpresaSelecionado",JSON.stringify(codigo));
    window.location.href = "detail.html";
}