function ClaimBoatBadge(Id) {
    $.ajax({
        type: "POST",
        url: "/Badge/ClaimBoatBadge",
        data: { Id: Id },
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function ClaimBirdBadge(Id) {
    $.ajax({
        type: "POST",
        url: "/Badge/ClaimBirdBadge",
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
