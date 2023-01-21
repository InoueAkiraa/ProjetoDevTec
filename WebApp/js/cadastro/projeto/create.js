function cadastrar(){
    var codigoProjeto = 0;
    var nome = $("#txtNome").val();
    var codigoEmpresa = $("#txtCodigoEmpresa").val();    
    var codigoTipoProjeto = $("#txtCodigoTipoProjeto").val();
    var descricao = $("#txtDescricao").val();
    var precoListado = $("#txtPrecoListado").val();
    var codigoStatusProjeto = $("#txtCodigoStatusProjeto").val();
    var siglaStatusProjeto = $("#txtSiglaStatusProjeto").val();
    var ativo = null;
    var dataInclusao = null;
    var dataInicio = $("#datDataInicio").val();
    var dataEntregaPrevista = $("#datDataEntregaPrevista").val();

    var novo = {
        codigoProjeto,
        nome,
        codigoEmpresa,
        codigoTipoProjeto,
        descricao,
        precoListado,
        codigoStatusProjeto,
        siglaStatusProjeto,
        ativo,
        dataInclusao,
        dataInicio,
        dataEntregaPrevista
    };

    console.log(novo);

    $.ajax({
        url: caminho,
        type: "post",
        dataType: "json",
        data: JSON.stringify(novo),
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoProjeto = data.codigoProjeto;
            alert("Dados gravados com sucesso. [CodigoProjeto = " + codigoProjeto + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });
}