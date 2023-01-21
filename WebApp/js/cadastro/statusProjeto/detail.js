var codigo = 0;


$(function(){
    avaliarAcao('statusProjetoAcao');
    if (acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if (acao == 1){
        $("#txtCodigoStatusProjeto").attr('readonly',true);
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoStatusProjeto").attr('readonly',true);
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
    $("#txtCodigoStatusProjeto").attr('readonly',true);
    $("#txtDescricao").attr('readonly',true);
    $("#txtSiglaStatusProjeto").attr('readonly',true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoStatusProjetoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoStatusProjetoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoStatusProjeto").val(data.codigoStatusProjeto);
            $("#txtDescricao").val(data.descricao);
            $("#txtSiglaStatusProjeto").val(data.siglaStatusProjeto);
        }
    });
}
