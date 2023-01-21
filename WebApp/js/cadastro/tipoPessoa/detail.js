var codigo = 0;

$(function(){
    avaliarAcao('tipoPessoaAcao');
    if (acao == 0){
        carregarDetalhe();
        somenteLeitura();    
        $("#btnNovo").hide();  
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();  
    }
    
    if (acao == 1){
        $("#txtCodigoTipoPessoa").attr('readonly', true);        
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
    }
    
    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoTipoPessoa").attr('readonly', true);
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
    $("#txtCodigoTipoPessoa").attr('readonly', true);
    $("#txtDescricao").attr('readonly', true);
    $("#txtSiglaTipoPessoa").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoTipoPessoaSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoTipoPessoaSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoTipoPessoa").val(data.codigoTipoPessoa);
            $("#txtDescricao").val(data.descricao);
            $("#txtSiglaTipoPessoa").val(data.siglaTipoPessoa);
        }
    });
}