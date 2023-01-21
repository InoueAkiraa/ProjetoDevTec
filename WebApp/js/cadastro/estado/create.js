console.log(caminho);

function cadastrar(){
    var codigoEstado = 0;
    var nome = $("#txtNome").val();
    var uf = $("#txtUF").val();

    var novo = {
        codigoEstado,
        nome,
        uf
    };

    $.ajax({
        url : caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data)
            codigoEstado = data.codigoEstado;
            alert("Dados gravados com sucesso! Codigo:" + codigoEstado);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados!" + status);
            return;
        }
    })
}
