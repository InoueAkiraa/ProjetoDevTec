console.log(caminho);

function alterar(){
    var codigoStatusProjeto = $("#txtCodigoStatusProjeto").val();
    var descricao = $("#txtDescricao").val();
    var siglaStatusProjeto = $("#txtSiglaStatusProjeto").val();
    
    var novo = {
        codigoStatusProjeto,
        descricao,
        siglaStatusProjeto
        
    };

    $.ajax({
        url: caminho,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoStatusProjeto = data.codigoStatusProjeto;
            alert("Dados alterados com sucesso. [CodigoStatusProjeto = " + codigoStatusProjeto + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao altera os dados. " + status);
            return;
        }
    });
}