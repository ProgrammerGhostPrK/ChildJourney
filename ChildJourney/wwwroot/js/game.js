function AddAnimal(buttonElement) {
    $(buttonElement).prop("disabled", true);
    $.ajax({
        type: "POST",
        url: "/Animal/AddAnimal",
    });
}
function AddMood(Grade, userId, Day) {
    $.ajax({
        type: "POST",
        url: "/Game/AddMood",
        data: { Grade: Grade, userId: userId, Day: Day},
        success: function (response) {
            handleSuccessResponse(response);
        }
    });
}
function AddCoins(Amount, buttonElement) {
    $(buttonElement).prop("disabled", true);

    $.ajax({
        type: "POST",
        url: "/Game/AddCoins",
        data: { Amount: Amount },
    });
}
function AddSeasonPoints(Amount, buttonElement) {
    $(buttonElement).prop("disabled", true);

    $.ajax({
        type: "POST",
        url: "/Game/AddSeasonPoints",
        data: { Amount: Amount },
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