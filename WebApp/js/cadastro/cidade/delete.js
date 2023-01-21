console.log(caminho);

function excluir(){
    var codigoCidade = $("#txtCodigoCidade").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url : caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data)
            codigoCidade = data.codigoCidade;
            alert("Dados excluidos com sucesso! Codigo cidade:" + codigoCidade);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados!" + status);
            return;
        }
    })
}
