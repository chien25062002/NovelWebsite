
$.ajax({
    url: "/Account/GetAccount",
    type: "POST",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        if (data == "") return;
        $('div.col.login').html('');
        let user = `<div class="dropdown"></div>
                    <div type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                        <img src="${data.avatar}" class="user-home-img dropdown-toggle">
                        ${data.username}
                    </div>
                        <ul class="dropdown-menu user-function" aria-labelledby="dropdownMenuButton1">
                            <li><a class="dropdown-item" href="#">Hồ sơ</a></li>
                            <li><a class="dropdown-item" href="#">Tủ truyện</a></li>
                            <li><a class="dropdown-item" href="#">Đăng tải</a></li>
                        </ul>`;
        $('div.col.login').append(user);
        if (data.role != 'Người dùng') {
            $('.user-function').append(`<li><a class="dropdown-item" href="/Area/Admin">Quản trị</a></li>`);
        }
        $('.user-function').append(`<li><a class="dropdown-item" href="/Account/Signout">Đăng xuất</a></li>`);
    },
    error: function () { },
    complete: function () { }
})