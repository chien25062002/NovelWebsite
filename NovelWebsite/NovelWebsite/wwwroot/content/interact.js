var isFav = false;
var isFollow = false;
var isRec = false;


function GetFav() {
    $.ajax({
        url: "/interact/getfav/" + bookId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isFav = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function GetRec() {
    $.ajax({
        url: "/interact/getrec/" + bookId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isRec = data;
        },
        error: function () { },
        complete: function () { }
    })
}

function GetFollow() {
    $.ajax({
        url: "/interact/getfollow/" + bookId,
        type: "GET",
        async: false,
        beforeSend: function () { },
        success: function (data) {
            isFollow = data;
        },
        error: function () { },
        complete: function () { }
    })
}


function UpdateFav() {
    $.ajax({
        url: "/interact/updatefav/" + bookId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdateRec() {
    $.ajax({
        url: "/interact/updaterec/" + bookId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}

function UpdateFollow() {
    $.ajax({
        url: "/interact/updatefollow/" + bookId,
        type: "GET",
        beforeSend: function () { },
        success: function (data) {
        },
        error: function () { },
        complete: function () { }
    })
}


function onClickInfoBtn(el, index) {
    if (index == 1) {
        UpdateFav();
        if ($(el).hasClass("selected")) {
            $(el).removeClass("selected");
            $(el).text("Yêu thích");
        } else {
            $(el).addClass("selected");
            $(el).text("Bỏ yêu thích")
        }
    }
    if (index == 2) {
        UpdateFollow();
        if ($(el).hasClass("selected")) {
            $(el).removeClass("selected");
            $(el).text("Theo dõi");
        } else {
            $(el).addClass("selected");
            $(el).text("Bỏ theo dõi")
        }
    }
    if (index == 3) {
        UpdateRec();
        if ($(el).hasClass("selected")) {
            $(el).removeClass("selected");
            $(el).text("Đề cử");
        } else {
            $(el).addClass("selected");
            $(el).text("Bỏ đề cử")
        }
    }

}