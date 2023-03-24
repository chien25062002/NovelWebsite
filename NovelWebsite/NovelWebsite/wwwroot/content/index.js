
$.ajax({
    url: "/Home/GetAllCategories",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('.index__theloai--wrap').html('');
        let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });
        data.forEach((item, index) => {
            row.append(`<div class="index__theloai--chitiet-cot col-md-6">
                                    <a href="javascript:void(0)">
                                        <i class="fa-solid fa-tags"></i>
                                        <span>
                                            <p class="tentruyen">${item.categoryName}</p>
                                            <p class="soluongtruyen">${item.quantity}</p>
                                        </span>
                                    </a>
                                </div>`);
            if (index % 2 == 1) {
                $('.index__theloai--wrap').append(row);
                row = jQuery('<div>', {
                    class: 'index__theloai--chitiet row',
                });;
            }
        });
        $('#chapter-category').html('');
        let row1 = jQuery('<ul>', {
            class: 'col-md-4',
        });
        let maxitem = Math.ceil(data.length / 3);
        /*console.log(data.length, maxitem)*/
        data.forEach((item, index) => {
            row1.append(`<li><a href="javascript:void(0)">${item.categoryName}</a></li>`);
            if ((index != 0 && index % maxitem == (maxitem - 1)) || index == data.length - 1) {
                /*console.log(index)*/
                $('#chapter-category').append(row1);
                row1 = jQuery('<ul>', {
                    class: 'col-md-4',
                });
            }
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetPosts?number=9",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#new-posts').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item ${index % 2 ? " odd" : ""}">
            <i class="fa-solid fa-share"></i>
            <a href="/tin-tuc/${item.id}${item.createdDate}/${item.slug}">${item.title}</a>
                                </li>`;
            $('#new-posts').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetChapterUpdated",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#new-chapters').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-book-open"></i>
                            <a href="/html/truyen.html">${item.book.bookName}</a>
                            <span class="index__truyenmoi--chuong">Chapter ${item.chapterNumber}</span>
                        </li>`;
            $('#new-chapters').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetEditorRecommends",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#editor-recommend').html('');
        let row = jQuery('<div>', {
            class: 'index__right-wrap--list row',
        });
        data.forEach((item, index) => {
            row.append(`<div class="index__right-wrap--listitem col-md-6">
                    <div class="book--img">
                        <a href="/truyen/${item.slug}-${item.bookId}">
                            <img src="${item.avatar}" class="book--imgcss">
                        </a>
                    </div>
                    <div class="book--info">
                        <div class="book-name">
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                        </div>
                        <div class="book-state">
                            <a href="javascript:void(0)">${item.author.authorName}</a >
                        </div>
                        <p>
                            <em>
                                <span class="chapters">${item.numberOfChapters}</span >
                            </em>
                            <cite>Chương</cite>
                            <i>|</i>
                            <em>
                                <span class="views">${item.views}</span >
                            </em>
                            <cite>Lượt xem</cite>
                        </p>
                        <div class="category">
                            <p>Thể loại:</p>
                            <p class="category-wrap">
                                <a href="javascript:void(0)">${item.category.categoryName}</a >
                            </p>
                        </div>
                        <div class="describe">
                            <i class="fa-solid fa-quote-left"></i>
                            ${item.introduce.replace(/<\/?[^>]+(>|$)/g, "").replace(/<\/?[^>]+(>|$)/g, "")}
                        </div>
                    </div>
                </div>`);
            if (index % 2 == 1) {
                $('#editor-recommend').append(row);
                row = jQuery('<div>', {
                    class: 'index__right-wrap--list row',
                });;
            }
        });
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Home/GetMostRecommends",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-recommends').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-recommends').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetMostViews",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-views').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-views').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetMostLikes",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-likes').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-likes').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetMostFollows",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#book-most-follows').html('');
        data.forEach((item, index) => {
            let row = `<li class="list-group-item">
                            <i class="fa-solid fa-star"></i>
                            <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a>
                        </li>`;
            $('#book-most-follows').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetNewBooks",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#newbook-avatar').html('');
        $('#newbook').html('');
        let row = jQuery('<div>', {
            class: 'index__right-wrap--list row',
        });
        data.forEach((item, index) => {
            if (index == 0) {
                $('#newbook-avatar').append(`<div class="index__left-wrap-detail card">
                                <img class="card-img-top" src="${item.avatar}" alt="Card image">
                                <div class="card-body">
                                    <h4 class="card-title">
                                        <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                    </h4>
                                    <p class="card-text index__left-wrap--theloai">${item.category.categoryName}</p >
                                    <p class="card-text index__left-wrap--sochuong">${item.numberOfChapters} Chương</p >
                                    <p class="card-text index__left-wrap--gioithieu">
                                        <i>
                                            ${item.introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0,255)}
                                        </i>
                                    </p>
                                    <a href="/truyen/${item.slug}-${item.bookId}" class="btn btn-primary index__left-wrap--cardbtn">
                                        Đọc truyện
                                        <i class="fa-solid fa-chevron-right"></i>
                                    </a>
                                </div>
                            </div>`);
            }
            else {
                row.append(`<div class="index__right-wrap--listitem col-md-4">
                            <div class="book--img">
                                <a href="/truyen/${item.slug}-${item.bookId}">
                                    <img src="${item.avatar}" class="book--imgcss">
                                </a>
                            </div>
                            <div class="book--info">
                                <div class="book-name">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                </div>
                                <div class="book-state">
                                    <a href="javascript:void(0)">${item.author.authorName}</a >
                                </div>
                                <p>
                                    <em>
                                        <span class="chapters">${item.numberOfChapters}</span >
                                    </em>
                                    <cite>Chương</cite>
                                    <i>|</i>
                                    <em>
                                        <span class="views">${item.views}</span >
                                    </em>
                                    <cite>Lượt xem</cite>
                                </p>
                                <div class="category">
                                    <p>Thể loại:</p>
                                    <p class="category-wrap">
                                        <a href="javascript:void(0)">${item.category.categoryName}</a >
                                    </p>
                                </div>
                                <div class="describe">
                                    <i class="fa-solid fa-quote-left"></i>
                                        ${item.introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0, 100)}
                                </div>
                            </div>
                        </div>`);
                if (index % 3 == 0) {
                    $('#newbook').append(row);
                    row = jQuery('<div>', {
                        class: 'index__right-wrap--list row',
                    });
                }
            }
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetFinishedBooks",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#finishbook-avatar').html('');
        $('#finishbook').html('');
        let row = jQuery('<div>', {
            class: 'index__right-wrap--list row',
        });
        console.log(data);
        data.forEach((item, index) => {
            if (index == 0) {
                $('#finishbook-avatar').append(`<div class="index__left-wrap-detail card">
                                <img class="card-img-top" src="${item.avatar}" alt="Card image">
                                <div class="card-body">
                                    <h4 class="card-title">
                                        <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                    </h4>
                                    <p class="card-text index__left-wrap--theloai">${item.category.categoryName}</p >
                                    <p class="card-text index__left-wrap--sochuong">${item.numberOfChapters} chương</p >
                                    <p class="card-text index__left-wrap--gioithieu">
                                        <i>
                                            ${item.introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0, 255)}
                                        </i>
                                    </p>
                                    <a href="/truyen/${item.slug}-${item.bookId}" class="btn btn-primary index__truyenmoito--cardbtn">
                                        Đọc truyện
                                        <i class="fa-solid fa-chevron-right"></i>
                                    </a>
                                </div>
                            </div>`);
            }
            else {
                row.append(`<div class="index__right-wrap--listitem col-md-4">
                            <div class="book--img">
                                <a href="/truyen/${item.slug}-${item.bookId}">
                                    <img src="${item.avatar}" class="book--imgcss">
                                </a>
                            </div>
                            <div class="book--info">
                                <div class="book-name">
                                    <a href="/truyen/${item.slug}-${item.bookId}">${item.bookName}</a >
                                </div>
                                <div class="book-state">
                                    <a href="javascript:void(0)">${item.author.authorName}</a >
                                </div>
                                <p>
                                    <em>
                                        <span class="chapters">${item.numberOfChapters}</span >
                                    </em>
                                    <cite>Chương</cite>
                                    <i>|</i>
                                    <em>
                                        <span class="views">${item.views}</span >
                                    </em>
                                    <cite>Lượt xem</cite>
                                </p>
                                <div class="category">
                                    <p>Thể loại:</p>
                                    <p class="category-wrap">
                                        <a href="javascript:void(0)">${item.category.categoryName}</a >
                                    </p>
                                </div>
                                <div class="describe">
                                    <i class="fa-solid fa-quote-left"></i>
                                        ${item.introduce.replace(/<\/?[^>]+(>|$)/g, "").substring(0, 100)}
                                </div>
                            </div>
                        </div>`);
                if (index % 3 == 0) {
                    $('#finishbook').append(row);
                    row = jQuery('<div>', {
                        class: 'index__right-wrap--list row',
                    });
                }
            }
        });
    },
    error: function () { },
    complete: function () { }
})