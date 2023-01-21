var codigo = 0;

$(function(){
    avaliarAcao('tipoProjetoAcao');
    if (acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if (acao == 1){
        $("#txtCodigoTipoProjeto").attr('readonly', true);
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoTipoProjeto").attr('readonly', true);
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
    $("#txtCodigoTipoProjeto").attr('readonly', true);
    $("#txtDescricao").attr('readonly', true);
    $("#txtLinguagem").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoTipoProjetoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoTipoProjetoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoTipoProjeto").val(data.codigoTipoProjeto);
            $("#txtDescricao").val(data.descricao);
            $("#txtLinguagem").val(data.linguagem);
        }
    });
}

