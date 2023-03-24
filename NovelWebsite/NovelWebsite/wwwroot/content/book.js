var queryString = window.location.href;
var param = queryString.split('-');
var id = param[param.length - 1];
var p = queryString.split('/');
var link = p[p.length - 1];

$.ajax({
    url: "/Book/GetListChapters?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#list-chuong').html('');
        /*let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });*/
        data.forEach((item, index) => {
            $('#list-chuong').append(`<li class="list-group-item col-4">
                        <a href="/truyen/${link}/chuong-${item.chapterNumber}-${item.slug}-${item.chapterId}">Chương ${item.chapterNumber}: ${item.chapterName}</a>
                        </li>`);
            /*if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Book/GetListReviews?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#list-review').html('');
        /*let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });*/
        console.log(data);
        $('#list-review').append(`<li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg">
                                    </a>
                                </div>
                                <div class="input-comment col">
                                        <div id="toolbar-container"></div>
                                        <div id="editor"></div>
                                </div>
                                <div class="submit-btn col-md-12">
                                    <div class="submit-btn-wrap">
                                        <button class="btn btn-primary onclick="AddReview(${bookId})">Đăng</button>
                                    </div>
                                </div>
                            </div>
                        </li>`)
        data.forEach((item, index) => {
            $('#list-review').append(`<li class="list-group-item">
                            <div class="row">
                                <div class="user--photo col-md-auto">
                                    <a href="javascript:void(0)">
                                        <img src="/image/test3.jpg">
                                    </a>
                                </div>
                                <div class="user--discussion col">
                                    <p class="users">
                                        <a href="javascript:void(0)">${item.user.userName}</a>
                                    </p>
                                    <p class="comments">
                                        ${item.content}
                                    </p>
                                    <p class="info--wrap">
                                        <span>${item.createdDate} </span>
                                        <a href="javascript:void(0)">
                                            <i class="fa-solid fa-square-caret-up info-icon rate-up"></i>
                                            ${item.likes}
                                        </a>
                                        <a href="javascript:void(0)">
                                            <i class="fa-solid fa-square-caret-down info-icon rate-down"></i>
                                            ${item.dislikes}
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </li>`);
/*            if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Book/GetListComments?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#list-comment').html('');
        /*let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });*/
        
        $('#list-comment').append(`<li class="list-group-item">
                                    <div class="row">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg">
                                            </a>
                                        </div>                                       
                                        <div class="input-comment col">
                                            <div id="toolbar-container"></div>
                                        </div>
                                        <div class="submit-btn col-md-12">
                                            <div class="submit-btn-wrap">
                                                <button class="btn btn-primary" onclick="AddBookComment(${bookId})">Đăng</button>
                                            </div>
                                        </div>
                                    </div>
                                </li>`);
        data.forEach((item, index) => {
            $('#list-comment').append(`<li class="list-group-item">
                                    <div class="row">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg">
                                            </a>
                                        </div>
                                        <div class="user--discussion col">
                                            <p class="users">
                                                <a href="javascript:void(0)">${item.userName}</a>
                                            </p>
                                            <p class="comments">
                                                ${item.content}
                                            </p>
                                            <p class="info--wrap">
                                                <span>${item.createdDate} </span>
                                                <a href="javascript:void(0)">
                                                    <i class="fa-solid fa-square-caret-up info-icon rate-up"></i>
                                                    ${item.likes}
                                                </a>
                                                <a href="javascript:void(0)">
                                                    <i class="fa-solid fa-square-caret-down info-icon rate-down"></i>
                                                    ${item.dislikes}
                                                </a>
                                            </p>
                                        </div>
                                    </div>
                                </li>`);
            /*if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Book/GetAuthorBooks?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-same-author').html('');
        /*        let row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });*/
        $('#book-same-author').append(`<li class="list-group-item">
                                <h5>Truyện cùng tác giả</h5>
                            </li>`)
        data.forEach((item, index) => {
            console.log(item);
            console.log(link);
            $('#book-same-author').append(`<li class="list-group-item">
                                <a href="/truyen/${item.slug}-${item.bookId}">&#x2022; ${item.bookName}</a>
                            </li>`);
            /*if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Book/GetUserBooks?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-same-user').html('');
        /*        let row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });*/
        $('#book-same-user').append(`<li class="list-group-item">
                                <h5>Truyện cùng người đăng</h5>
                            </li>`)
        data.forEach((item, index) => {
            $('#book-same-user').append(`<li class="list-group-item">
                                <a href="/truyen/${item.slug}-${item.bookId}">&#x2022; ${item.bookName}</a>
                            </li>`);
            /*if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Book/BooksMaybeYouLike?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-same-like').html('');
        /*let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });*/
        console.log()
        data.forEach((item, index) => {
            $('#book-same-like').append(`<li class="list-group-item">
                                <div class="like-more-img">
                                    <a href="/truyen/${item.slug}-${item.bookId}">
                                        <img src="${item.avatar}">
                                    </a>
                                </div>
                                <h4 class="relate-content">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                                    <p>${item.author.authorName}</p>
                                    <a href="/truyen/${item.slug}-${item.bookId}" class="btn index__left-wrap--cardbtn truyen-btn">
                                        Đọc truyện
                                        <i class="fa-solid fa-chevron-right"></i>
                                    </a>
                                </h4>
                            </li>`);
            /*if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }*/
        });
    },
    error: function () { },
    complete: function () { }
})