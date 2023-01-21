function alterar(){
    var codigoTipoPessoa = $("#txtCodigoTipoPessoa").val();
    var descricao = $("#txtDescricao").val();
    var siglaTipoPessoa = $("#txtSiglaTipoPessoa").val();    

    var novo = {
        codigoTipoPessoa,
        descricao,
        siglaTipoPessoa
    };

    $.ajax({
        url: caminho,
        type: "put",
        dataType: "json",
        data: JSON.stringify(novo),
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoPessoa = data.codigoTipoPessoa;
            alert("Dados alterados com sucesso. [CodigoTipoPessoa = " + codigoTipoPessoa + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao alterar os dados. " + status);
            return;
        }
    });

}