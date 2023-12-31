﻿
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
function BuyBodyPart(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/BuyBodyPart",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function BuyClothing(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/BuyClothing",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function BuyIsland(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/BuyIsland",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function AddCoins(Amount) {
    $.ajax({
        type: "POST",
        url: "/Game/AddCoins",
        data: { Amount: Amount },
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