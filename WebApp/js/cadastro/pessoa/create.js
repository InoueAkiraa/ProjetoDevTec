function cadastrar(){
    var codigoPessoa = 0;
    var nome = $("#txtNome").val();
    var sobrenome = $("#txtSobrenome").val();
    var email = $("#txtEmail").val();
    var telefone = $("#txtTelefone").val();
    var matricula = $("#txtMatricula").val();
    var documento = $("#txtDocumento").val();
    var codigoTipoPessoa = $("#txtCodigoTipoPessoa").val();
    var siglaTipoPessoa = $("#txtSiglaTipoPessoa").val();
    var ativo = null;
    var dataInclusao = null;
    var dataContratacao = $("#DatDataContratacao").val();
    
    var novo = {
        codigoPessoa,
        nome,
        sobrenome,
        email,
        telefone,
        matricula,
        documento,
        codigoTipoPessoa,
        siglaTipoPessoa,
        ativo,
        dataInclusao,
        dataContratacao
    };

    $.ajax({
        url: caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoPessoa = data.codigoPessoa;
            alert("Dados gravados com sucesso. [CodigoPessoa = " + codigoPessoa + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });
}


