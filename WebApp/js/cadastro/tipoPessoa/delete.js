function excluir(){
    var codigoTipoPessoa = $("#txtCodigoTipoPessoa").val();   
    var caminhoDelete = caminho + '/' + codigo;

    $.ajax({
        url: caminhoDelete,
        type: "delete",
        dataType: "json",
        data: null,
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoPessoa = data.codigoTipoPessoa;
            alert("Dados excluídos com sucesso. [CodigoTipoPessoa = " + codigoTipoPessoa + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });

}