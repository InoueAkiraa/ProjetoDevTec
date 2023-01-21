console.log(caminho);

function alterar(){
    var codigoEmpresa = $("#txtCodigoEmpresa").val();
    var descricao = $("#txtDescricao").val();
    var cnpj = $("#txtCNPJ").val();
    var razaosocial = $("#txtRazaoSocial").val();

    var novo = {
        codigoEmpresa,
        descricao,
        cnpj,
        razaosocial
    };

    $.ajax({
        url: caminho,
        type: "put",
        datatype: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoEmpresa = data.codigoEmpresa;
            alert("Dados alterados com sucesso. [CodigoEmpresa= " + codigoEmpresa + "]");
            window.location.href = "list.html"; 
        },
        error:function (xhr, status, errorThrown){
            alert("Erro ao alterar os dados.");
            return;
        }
    })

}