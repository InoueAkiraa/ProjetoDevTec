function cadastrar(){
    var codigoTipoPessoa = 0;
    var descricao = $("#txtDescricao").val();
    var siglaTipoPessoa = $("#txtSiglaTipoPessoa").val();    

    var novo = {
        codigoTipoPessoa,
        descricao,
        siglaTipoPessoa
    };

    $.ajax({
        url: caminho,
        type: "post",
        dataType: "json",
        data: JSON.stringify(novo),
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoPessoa = data.codigoTipoPessoa;
            alert("Dados gravados com sucesso. [CodigoTipoPessoa = " + codigoTipoPessoa + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });

}