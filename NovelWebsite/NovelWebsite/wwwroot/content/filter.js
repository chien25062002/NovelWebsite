$.ajax({
    url: "/Filter/GetAllTags",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    context: this,
    success: function (data) {
        $('#filter-tags').html("");
        data.forEach((item, index) => {
            let row = ` <li class="nav-item">
                                                <a href="javascript:void(0)">${item.tagName}</a>
                                            </li>`;
            $('#filter-tags').append(row);
        });
    },
    error: function () { },
    complete: function () { }
});

$.ajax({
    url: "/Filter/GetBookStatuses",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    context: this,
    success: function (data) {
        $('#filter-status').html("");
        data.forEach((item, index) => {
            let row = `<li class="nav-item">
                            <a href="javascript:void(0)">${item.bookStatusName}</a>
                        </li>`;
            $('#filter-status').append(row);
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Home/GetAllCategories",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#type-list').html(`<i>·</i>`);
        data.forEach((item, index) => {
            let row = `<a href="javascript:void(0)" onclick="typeListClick(this)">${item.categoryName}</a><i>·</i>`;
            $('#type-list').append(row);
        });
    },
    error: function () { },
    complete: function () { }
});

/*$(document).ready(function () {
    $(".rank-box-item-box li a").click(function () {
        var element = $(".rank-box-item-box li a");
        element.parent().toggleClass("box-active");
    });*/



