var codigo = 0;

$(function(){
    avaliarAcao("estadoAcao")
    if(acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if(acao == 1){
        $("#txtCodigoEstado").attr('readonly', true);
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if(acao == 2){
        carregarDetalhe();
        $("#txtCodigoEstado").attr('readonly', true);
        $("#btnNovo").hide();
        $("#btnExcluir").hide();
    }

    if(acao == 3){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
    }
});

function somenteLeitura(){
    $("#txtCodigoEstado").attr('readonly', true);
    $("#txtNome").attr('readonly', true)
    $("#txtUF").attr('readonly', true)
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoEstadoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoEstadoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoEstado").val(data.codigoEstado);
            $("#txtNome").val(data.nome);
            $("#txtUF").val(data.uf);
        }
    });
}