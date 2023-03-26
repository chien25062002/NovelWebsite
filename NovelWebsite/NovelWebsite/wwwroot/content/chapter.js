var queryString = window.location.href;
var param = queryString.split('-');
var id = param[param.length - 1];

/*$.ajax({
    url: "/Account/GetAccount",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('.col.login').html('');
     
    },
    error: function () { },
    complete: function () { }
})*/
console.log(123456)
$.ajax({
    url: "/Chapter/GetAllCategories",
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#chapter-category').html('');
        let row = jQuery('<ul>', {
            class: 'col-md-4',
        });
        let maxitem = Math.ceil(data.length / 3);
        console.log(data.length, maxitem)
        data.forEach((item, index) => {
            row.append(`<li><a href="javascript:void(0)">${item.categoryName}</a></li>`);
            if ((index != 0 && index % maxitem == (maxitem - 1)) || index == data.length - 1) {

                console.log(index)
                $('#chapter-category').append(row);
                row = jQuery('<ul>', {
                    class: 'col-md-4',
                });
            }
        });
    },
    error: function () { },
    complete: function () { }
})

$.ajax({
    url: "/Chapter/GetListComments?id=" + id,
    type: "GET",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        $('#list-comment-chapter').html('');
        /*let row = jQuery('<div>', {
            class: 'index__theloai--chitiet row',
        });*/
        $('#list-comment-chapter').append(`<li class="list-group-item">
                                    <div class="row">
                                        <div class="user--photo col-md-auto">
                                            <a href="javascript:void(0)">
                                                <img src="/image/test3.jpg">
                                            </a>
                                        </div>
                                        <div class="input-comment col">
                                            <textarea></textarea>
                                            <script>
                                                tinymce.init({
                                                    selector: 'textarea',
                                                    branding: false,
                                                    elementpath: false,
                                                    menubar: false,
                                                });
                                            </script>
                                        </div>
                                        <div class="submit-btn col-md-12">
                                            <div class="submit-btn-wrap">
                                                <button class="btn btn-primary">Đăng</button>
                                            </div>
                                        </div>
                                    </div>
                                </li>`);
        console.log(data)
        data.forEach((item, index) => {
            $('#list-comment-chapter').append(`<li class="list-group-item">
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
    error: function (e) { console.log(e) },
    complete: function () { }
})
