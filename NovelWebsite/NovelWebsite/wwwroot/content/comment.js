
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
            Content: $('#chapter-editor').html()
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



function AddPostComment(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            PostId: id,
            UserId: user.userId,
            Content: $('#postcomment-editor').html()
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

function AddReplyComment(id) {
    var user = GetUserInfo();
    var contentEle = '#reply' + id + '-editor';
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            ReplyCommentId: id,
            UserId: user.userId,
            Content: $(contentEle).html()
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