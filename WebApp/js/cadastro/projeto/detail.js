var codigo = 0;

$(function(){
    avaliarAcao('projetoAcao');
    if (acao == 0){
        carregarDetalhe();
        somenteLeitura();    
        $("#btnNovo").hide();  
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();  
        $("#divData").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('disabled', true);
    }
    
    if (acao == 1){
        $("#txtCodigoProjeto").attr('readonly', true);  
        $("#txtAtivo").attr('readonly', true); 
        $("#txtDataInclusao").attr('readonly', true);      
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#divTexto").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('checked', true);
        $("#chbAtivo").attr('disabled', true);
    }
    
    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoProjeto").attr('readonly', true);
        $("#txtDataInclusao").attr('readonly', true); 
        $("#btnNovo").hide(); 
        $("#btnExcluir").hide();  
        $("#divTexto").hide();
        $("#datDataInicio").attr('readonly', true);
        $("#divAtivoInclusao").hide();
    }

    if (acao == 3){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();  
        $("#btnAlterar").hide();
        $("#divData").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('disabled', true);
    }
});

function somenteLeitura(){
    $("#txtCodigoProjeto").attr('readonly', true);
    $("#txtNome").attr('readonly', true);
    $("#txtCodigoEmpresa").attr('readonly', true);
    $("#txtCodigoTipoProjeto").attr('readonly', true);
    $("#txtDescricao").attr('readonly', true);
    $("#txtPrecoListado").attr('readonly', true);
    $("#txtCodigoStatusProjeto").attr('readonly', true);
    $("#txtSiglaStatusProjeto").attr('readonly', true);
    $("#txtAtivo").attr('readonly', true);
    $("#txtDataInclusao").attr('readonly', true);
    $("#txtDataInicio").attr('readonly', true);
    $("#txtDataEntregaPrevista").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoProjetoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoProjetoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;
    
    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoProjeto").val(data.codigoProjeto);
            $("#txtNome").val(data.nome)
            $("#txtCodigoEmpresa").val(data.codigoEmpresa);
            $("#txtCodigoTipoProjeto").val(data.codigoTipoProjeto);
            $("#txtDescricao").val(data.descricao);
            $("#txtPrecoListado").val(data.precoListado);
            $("#txtCodigoStatusProjeto").val(data.codigoStatusProjeto);
            $("#txtSiglaStatusProjeto").val(data.siglaStatusProjeto);
            $("#txtAtivo").val(data.ativo);
            $("#txtDataInclusao").val(data.dataInclusao.substring(0,10));
            $("#txtDataInicio").val(data.dataInicio.substring(0,10));
            $("#datDataInicio").val(data.dataInicio.substring(0,10));
            $("#txtDataEntregaPrevista").val(data.dataEntregaPrevista.substring(0,10));
            $("#datDataEntregaPrevista").val(data.dataEntregaPrevista.substring(0,10));
            $("#chbAtivo").attr('checked', (stringToBoolean(data.ativo)));
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'true');
}