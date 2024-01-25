function AddToBody(Id) {
    $.ajax({
        type: "POST",
        url: "/BodyPart/AddToBody",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function AddToHouse(Id) {
    $.ajax({
        type: "POST",
        url: "/Decoration/AddToHouse",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function AddToOutfit(Id) {
    $.ajax({
        type: "POST",
        url: "/Clothing/AddToOutfit",
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
