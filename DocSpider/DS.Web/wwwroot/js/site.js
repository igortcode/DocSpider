

function DownloadFile(id) {

    var path = "/Arquivo/Download/"+id

    $.ajax({
        url: path
        , type: "GET"
        , success: function () {
        },
        error: function (response) {
            alert("Não deu certo");
        },
        failure: function (xhr) {
            alert("Não deu certo");
        }
    });
}

function DeleteArquivo(id) {
    debugger;
    if (confirm("Gostaria de excluir o arquivo?")) {
        var path = "/Arquivo/Delete/" + id

        $.ajax({
            url: path
            , type: "GET"
            , success: function () {
                alert("Excluído com sucesso!");
                location.reload();
            },
            error: function (response) {
                alert("Excluído com sucesso!");
                location.reload();
            },
            failure: function (xhr) {
                alert("Falhou");
            }
        });
    }
    else
        alert("Arquivo mantido!");


   
}
