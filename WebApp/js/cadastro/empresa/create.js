console.log(caminho);

function cadastrar(){

    var codigoEmpresa = 0;
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
        type: "post",
        datatype: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoEmpresa = data.codigoEmpresa;
            alert("Dados gravados com sucesso. [CodigoEmpresa= " + codigoEmpresa + "]");
            window.location.href = "list.html"; 
        },
        error:function (xhr, status, errorThrown){
            alert("Erro ao gravar os dados.");
            return;
        }
    })

}