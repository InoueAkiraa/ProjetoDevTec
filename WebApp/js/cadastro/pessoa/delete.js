function excluir(){
    var codigoPessoa = $("#txtCodigoPessoa").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoPessoa = data.codigoPessoa;
            alert("Dados excluídos com sucesso. [CodigoPessoa = " + codigoPessoa + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}