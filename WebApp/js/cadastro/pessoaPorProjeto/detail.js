var codigo = 0;

$(function(){
    carregar();
});

function carregar(){
    var tmp = localStorage.getItem("codigoEnderecoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoEnderecoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoEndereco").val(data.codigoEndereco);
            $("#txtRua").val(data.rua);
            $("#txtNumero").val(data.numero);
            $("#txtCodigoEstado").val(data.complemento);
            $("#txtBairro").val(data.bairro);
            $("#txtCEP").val(data.cep);
            $("#txtCodigoCidade").val(data.codigoCidade);
        }
    });
}