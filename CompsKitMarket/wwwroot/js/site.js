// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function CallRemove(url) {
    if (!confirm("Вы уверены, что хотите удалить эту запись?")) {
        return;
    }
    $.ajax({
        type: "Delete",
        url: url,
        success: function (response) {
            //обновить таблицу
            alert("Запись удалена");
        },
        failure: function (response) {
            console.error(response.responseText);
        },
        error: function (response) {
            console.error(response.responseText);
        }
    });
}
function editModal(url, feedback) {
    $.ajax({
        type: "POST",
        url: url,
        success: function (response) {
            $("#for-modal").html(response);
            $("#directoryModal").modal('show')
            if (feedback)
                feedback();
            location.reload();
        },
        failure: function (response) {
            console.error(response.responseText);
        },
        error: function (response) {
            console.error(response.responseText);
        }
    });
}