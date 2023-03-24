
function AddBookComment(id) {
    console.log($("book-comment").text());
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            BookId: id,
            Content: tinymce.get("book-comment").getContent()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            console.log("success");
        },
        error: function () { },
        complete: function () { }
    })
}

function AddChapterComment(id) {
    $.ajax({
        url: "/Comment/AddComment",
        type: "POST",
        data: {
            ChapterId: id,
            Content: tinymce.get("chapter-comment").getContent()
        },
        dataType: "json",
        beforeSend: function () { },
        success: function () {
            console.log("success");
        },
        error: function () { },
        complete: function () { }
    })
}