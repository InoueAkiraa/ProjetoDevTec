console.log(caminho);

function alterar(){
    
    var codigoCidade = $("#txtcodigoCidade").val();
    var nome = $("#txtNome").val();
    var codigoIbge7 = $("#txtCodigoIBGE7").val();
    var codigoEstado = $("#txtCodigoEstado").val();

    var novo = {
        codigoCidade,
        nome,
        codigoIbge7,
        codigoEstado
    };

    $.ajax({
        url : caminho,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data)
            codigoCidade = data.codigoCidade;
            alert("Dados alterados com sucesso! Codigo:" + codigoCidade);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao alterar os dados!" + status);
            return;
        }
    })
}
