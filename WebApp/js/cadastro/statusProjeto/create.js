function cadastrar(){
    var codigoStatusProjeto = 0;
    var descricao = $("#txtDescricao").val();
    var siglaStatusProjeto = $("#txtSiglaStatusProjeto").val();
    
    var novo = {
        codigoStatusProjeto,
        descricao,
        siglaStatusProjeto
        
    };

    $.ajax({
        url: caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoStatusProjeto = data.codigoStatusProjeto;
            alert("Dados gravados com sucesso. [CodigoStatusProjeto = " + codigoStatusProjeto + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });
}