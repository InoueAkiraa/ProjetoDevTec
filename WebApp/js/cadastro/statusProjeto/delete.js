console.log(caminho);

function excluir(){
    var codigoStatusProjeto = $("#txtCodigoStatusProjeto").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoStatusProjeto = data.codigoStatusProjeto;
            alert("Dados excluídos com sucesso. [CodigoStatusProjeto = " + codigoStatusProjeto + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}