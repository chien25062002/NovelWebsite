
function AddBookComment(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            BookId: id,
            UserId: user.userId,
            Content: $('#comment-editor').html()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            console.log("success");
            location.reload();
        },
        error: function () { },
        complete: function () { }
    })
}

function AddChapterComment(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            ChapterId: id,
            UserId: user.userId,
            Content: $('#comment-editor').html()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            console.log("success");
            location.reload();
        },
        error: function () { },
        complete: function () { }
    })
}