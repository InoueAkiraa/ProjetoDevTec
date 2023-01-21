console.log(caminho);

function alterar(){
    var codigoEstado = $("#txtCodigoEstado").val();
    var nome = $("#txtNome").val();
    var uf = $("#txtUF").val();

    var novo = {
        codigoEstado,
        nome,
        uf
    };

    $.ajax({
        url : caminho,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data)
            codigoEstado = data.codigoEstado;
            alert("Dados alterados com sucesso! Codigo:" + codigoEstado);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao alterar os dados!" + status);
            return;
        }
    })
}
