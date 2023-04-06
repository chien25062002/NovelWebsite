function GetUserInfo() {
    var user = "";
    $.ajax({
        url: "/Account/GetUser",
        async: false,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            console.log(data);
            user = data;
        },
        error: function () { },
        complete: function () { }
    });
    return user;
}

var user = GetUserInfo();