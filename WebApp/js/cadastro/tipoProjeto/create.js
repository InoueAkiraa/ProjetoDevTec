function cadastrar(){
    var codigoTipoProjeto = 0;
    var descricao = $("#txtDescricao").val();
    var linguagem = $("#txtLinguagem").val();

    var novo = {
        codigoTipoProjeto,
        descricao,
        linguagem
    };

    $.ajax({
        url: caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoTipoProjeto = data.codigoTipoProjeto;
            alert("Dados gravados com sucesso. [CodigoTipoProjeto = " + codigoTipoProjeto + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });
}
