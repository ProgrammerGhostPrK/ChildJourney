﻿
function DeleteWeeklies() {
    $.ajax({
        type: "POST",
        url: "/Reward/DeleteWeeklies",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteSeasonal() {
    $.ajax({
        type: "POST",
        url: "/Reward/DeleteSeasonal",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllRewards() {
    $.ajax({
        type: "POST",
        url: "/Reward/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllIslands() {
    $.ajax({
        type: "POST",
        url: "/Island/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllUsers() {
    $.ajax({
        type: "POST",
        url: "/User/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllAnimals() {
    $.ajax({
        type: "POST",
        url: "/Animal/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllBadges() {
    $.ajax({
        type: "POST",
        url: "/Badge/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllBodyParts() {
    $.ajax({
        type: "POST",
        url: "/BodyPart/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllClothing() {
    $.ajax({
        type: "POST",
        url: "/Clothing/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function DeleteAllDeco() {
    $.ajax({
        type: "POST",
        url: "/Decoration/DeleteAll",
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function ClaimReward(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/ClaimReward",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function ClaimSeasonalReward(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/ClaimSeasonalReward",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
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
function AddToHouse(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/AddToHouse",
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
function BuyDecoration(Id) {
    $.ajax({
        type: "POST",
        url: "/Game/BuyDecoration",
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