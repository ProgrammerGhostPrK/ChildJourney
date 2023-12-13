
function AddToArray(string, List) {
    List.push(string);
}
function AddToOutfit(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/AddToOutfit",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function AddToBody(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/AddToBody",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function handleSuccessResponse(response) {
    if (response.success) {
        console.log(response.message);

        if (response.refreshPage) {
            location.reload(true);
        }
    }
}