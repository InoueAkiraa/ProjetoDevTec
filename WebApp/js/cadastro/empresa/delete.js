console.log(caminho);

function excluir(){
    var codigoEmpresa = $("#txtCodigoEmpresa").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        datatype: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoEmpresa = data.codigoEmpresa;
            alert("Dados deletados com sucesso. [CodigoEmpresa= " + codigoEmpresa + "]");
            window.location.href = "list.html"; 
        },
        error:function (xhr, status, errorThrown){
            alert("Erro ao deletar os dados.");
            return;
        }
    })

}