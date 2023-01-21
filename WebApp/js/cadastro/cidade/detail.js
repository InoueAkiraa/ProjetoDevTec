var codigo = 0;

$(function(){
    avaliarAcao("cidadeAcao")
    if(acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if(acao == 1){
        $("#txtCodigoCidade").attr('readonly', true);
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }

    if(acao == 2){
        carregarDetalhe();
        $("#txtCodigoCidade").attr('readonly', true);
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
    $("#txtCodigoCidade").attr('readonly', true);
    $("#txtNome").attr('readonly', true)
    $("#txtCodigoIBGE7").attr('readonly', true);
    $("#txtCodigoEstado").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoCidadeSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoCidadeSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;
    
    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoCidade").val(data.codigoCidade);
            $("#txtNome").val(data.nome);
            $("#txtCodigoIBGE7").val(data.codigoIBGE7);
            $("#txtCodigoEstado").val(data.codigoEstado);
        }
    });
}