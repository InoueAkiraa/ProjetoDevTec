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
            const endereco = data[index];
            
            console.log(endereco);

            var codigo = endereco.codigoEndereco;
            var rua = endereco.rua;
            var numero = endereco.numero;
            var complemento = endereco.complemento;
            var bairro = endereco.bairro;
            var cep = endereco.cep;
            var codigoCidade = endereco.codigoCidade;

            var linha = '';
            linha += "<tr>";
            linha += "<td class='table-active text-center'><button id='btnExibir' class='border-light border-0' onclick='exibir("+ codigo +");'> <img src='/img/att.png''width=35 height=35'></button></td>";
            linha += "<td class='table-active text-center'>" + codigo + "</td>";
            linha += "<td class='table-active text-center'>" + rua + "</td>";
            linha += "<td class='table-active text-center'>" + numero + "</td>";
            linha += "<td class='table-active text-center'>" + complemento + "</td>";
            linha += "<td class='table-active text-center'>" + bairro + "</td>";
            linha += "<td class='table-active text-center'>" + cep + "</td>";
            linha += "</tr>";
            
            $("#tblDados tbody").append(linha);
          }
        }

    });
}

function exibir(codigo){
    localStorage.setItem("codigoEnderecoSelecionado",JSON.stringify(codigo));
    window.location.href = "detail.html";
}