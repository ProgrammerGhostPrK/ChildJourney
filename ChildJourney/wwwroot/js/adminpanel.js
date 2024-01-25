function DeleteDatabase() {
    $.ajax({
        type: "POST",
        url: "/Home/DeleteDatabase",
        success: function (data) {
            if (data.success) {
                window.location.href = data.redirectUrl;
            }
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
function handleSuccessResponse(response) {
    if (response.success) {
        console.log(response.message);

        if (response.refreshPage) {
            location.reload(true);
        }
    }
}
