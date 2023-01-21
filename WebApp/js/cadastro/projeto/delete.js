function excluir(){
    var codigoProjeto = $("#txtCodigoProjeto").val();   
    var caminhoDelete = caminho + '/' + codigo;

    $.ajax({
        url: caminhoDelete,
        type: "delete",
        dataType: "json",
        data: null,
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoProjeto = data.codigoProjeto;
            alert("Dados excluídos com sucesso. [CodigoProjeto = " + codigoProjeto + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });

}