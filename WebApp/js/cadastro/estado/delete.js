console.log(caminho);

function excluir(){
    var codigoEstado = $("#txtCodigoEstado").val();
    var nome = $("#txtNome").val();
    var uf = $("#txtUF").val();

    var novo = {
        codigoEstado,
        nome,
        uf
    };

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url : caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data)
            codigoEstado = data.codigoEstado;
            alert("Dados excluidos com sucesso! Codigo:" + codigoEstado);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados!" + status);
            return;
        }
    })
}
