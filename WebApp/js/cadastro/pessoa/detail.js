var codigo = 0;

$(function(){
    avaliarAcao('pessoaAcao');
    if (acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#Data").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('disabled', true);
    }

    if (acao == 1){
        $("#txtCodigoPessoa").attr('readonly',true);
        $("#txtAtivo").attr('readonly',true);
        $("#txtDataInclusao").attr('readonly', true); 
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('checked', true);
        $("#chbAtivo").attr('disabled', true);
    }

    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoPessoa").attr('readonly',true);
        $("#txtDataInclusao").attr('readonly', true);  
        $("#btnNovo").hide();
        $("#btnExcluir").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#DatDataContratacao").attr('readonly', true);  
    }

    if (acao == 3){
       carregarDetalhe();
       somenteLeitura();
       $("#btnNovo").hide();
       $("#btnAlterar").hide();
       $("#Data").hide();
       $("#divAtivoInclusao").hide();
       $("#chbAtivo").attr('disabled', true);
    }
});

function somenteLeitura(){
    $("#txtCodigoPessoa").attr('readonly',true);
    $("#txtNome").attr('readonly',true);
    $("#txtSobrenome").attr('readonly',true);
    $("#txtEmail").attr('readonly',true);
    $("#txtTelefone").attr('readonly',true);
    $("#txtMatricula").attr('readonly',true);
    $("#txtDocumento").attr('readonly',true);
    $("#txtCodigoTipoPessoa").attr('readonly',true);
    $("#txtSiglaTipoPessoa").attr('readonly',true);
    $("#txtAtivo").attr('readonly',true);
    $("#txtDataInclusao").attr('readonly', true);
    $("#txtDataContratacaoText").attr('readonly',true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoPessoaSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoPessoaSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoPessoa").val(data.codigoPessoa);
            $("#txtNome").val(data.nome)
            $("#txtSobrenome").val(data.sobrenome);
            $("#txtEmail").val(data.email);
            $("#txtTelefone").val(data.telefone);
            $("#txtMatricula").val(data.matricula);
            $("#txtDocumento").val(data.documento);
            $("#txtCodigoTipoPessoa").val(data.codigoTipoPessoa);
            $("#txtSiglaTipoPessoa").val(data.siglaTipoPessoa);
            $("#txtAtivo").val(data.ativo);
            $("#txtDataInclusao").val(data.dataInclusao.substring(0,10));
            $("#txtDataContratacaoText").val(data.dataContratacao.substring(0,10));
            $("#DatDataContratacao").val(data.dataContratacao.substring(0,10));
            $("#chbAtivo").attr('checked', (stringToBoolean(data.ativo)));
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'true');
}