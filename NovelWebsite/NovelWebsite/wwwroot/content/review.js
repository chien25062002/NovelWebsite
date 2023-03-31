function AddReview(id) {
    var user = GetUserInfo();
    if (user == "") {
        alert("Bạn cần đăng nhập để có thể bình luận!");
        return;
    }
    $.ajax({
        url: "/Review/AddReview",
        type: "POST",
        data: {
            BookId: id,
            UserId: user.userId,
            Content: $('#review-editor').html()
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