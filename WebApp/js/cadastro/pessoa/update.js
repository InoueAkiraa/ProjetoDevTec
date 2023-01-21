function alterar(){
    var codigoPessoa = $("#txtCodigoPessoa").val();
    var nome = $("#txtNome").val();
    var sobrenome = $("#txtSobrenome").val();
    var email = $("#txtEmail").val();
    var telefone = $("#txtTelefone").val();
    var matricula = $("#txtMatricula").val();
    var documento = $("#txtDocumento").val();
    var codigoTipoPessoa = $("#txtCodigoTipoPessoa").val();
    var siglaTipoPessoa = $("#txtSiglaTipoPessoa").val();
    var ativo = $("#chbAtivo").prop('checked');
    
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
        ativo
    };

    $.ajax({
        url: caminho,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoPessoa = data.codigoPessoa;
            alert("Dados alterados com sucesso. [CodigoPessoa = " + codigoPessoa + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao altera os dados. " + status);
            return;
        }
    });
}

