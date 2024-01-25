function BuyBodyPart(Id) {
    $.ajax({
        type: "POST",
        url: "/BodyPart/BuyBodyPart",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function BuyDecoration(Id) {
    $.ajax({
        type: "POST",
        url: "/Decoration/BuyDecoration",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function BuyClothing(Id) {
    $.ajax({
        type: "POST",
        url: "/Clothing/BuyClothing",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function BuyIsland(Id) {
    $.ajax({
        type: "POST",
        url: "/Island/BuyIsland",
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