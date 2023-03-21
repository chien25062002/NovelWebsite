$.ajax({
    url: "/Home/GetListChapters",
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
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetListReviews",
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
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Home/GetListComments",
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
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Home/GetAuthorBooks",
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
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Home/GetUserBooks",
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
    },
    error: function () { },
    complete: function () { }
})


$.ajax({
    url: "/Home/BooksMaybeYouLike",
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
    },
    error: function () { },
    complete: function () { }
})