var codigo = 0;

$(function(){
    avaliarAcao('empresaAcao');
    if(acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if (acao == 1){
        $("#txtCodigoEmpresa").attr('readonly', true);
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoEmpresa").attr('readonly', true);
        $("#btnNovo").hide();
        $("#btnExcluir").hide();
    }

    if (acao == 3){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
    }
});

function somenteLeitura(){
    $("#txtCodigoEmpresa").attr('readonly', true);
    $("#txtDescricao").attr('readonly', true);
    $("#txtCNPJ").attr('readonly', true);
    $("#txtRazaoSocial").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoEmpresaSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoEmpresaSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoEmpresa").val(data.codigoEmpresa);
            $("#txtDescricao").val(data.descricao);
            $("#txtCNPJ").val(data.cnpj);
            $("#txtRazaoSocial").val(data.razaoSocial);
        }
    });
}