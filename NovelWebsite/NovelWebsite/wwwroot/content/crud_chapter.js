function DeleteChapter(chapterId) {
    $.ajax({
        url: "/Chapter/DeleteChapter?chapterId=" + chapterId,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        context: this,
        success: function (data) {
            location.reload();
        },
        error: function () { },
        complete: function () { }
    });
}