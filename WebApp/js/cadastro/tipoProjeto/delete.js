function excluir(){
    var codigoTipoProjeto = $("#txtCodigoTipoProjeto").val();

    var caminhoComValor = caminho + '/' + codigo;
    
    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoProjeto = data.codigoTipoProjeto;
            alert("Dados excluídos com sucesso. [CodigoTipoProjeto = " + codigoTipoProjeto + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}
