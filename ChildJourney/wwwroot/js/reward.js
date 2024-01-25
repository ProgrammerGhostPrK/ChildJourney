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
function ClaimReward(Id) {
    $.ajax({
        type: "POST",
        url: "/Reward/ClaimReward",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function ClaimSeasonalReward(Id) {
    $.ajax({
        type: "POST",
        url: "/Reward/ClaimSeasonalReward",
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