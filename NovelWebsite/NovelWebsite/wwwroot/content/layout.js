$.ajax({
    url: "/Account/GetAccount",
    type: "POST",
    dataType: "json",
    beforeSend: function () { },
    success: function (data) {
        if (data == "") return;
        $('div.col.login').html('');
        let user = `<div class="dropdown">
                        <button class="btn btn-secondary" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <img src="${data.avatar}" class="user-home-img">
                            <div class="user-home-name"><p>${data.username}</p></div>
                        </button>
                        <ul class="dropdown-menu user-function dropdown-menu-end" aria-labelledby="dropdownMenuButton1">
                            <li><a class="dropdown-item" href="#">Hồ sơ</a></li>
                            <li><a class="dropdown-item" href="#">Tủ truyện</a></li>
                            <li><a class="dropdown-item" href="#">Đăng tải</a></li>
                        </ul>
                    </div>`;
        $('div.col.login').append(user);
        if (data.role != 'Người dùng') {
            $('.user-function').append(`<li><a class="dropdown-item" href="/Admin">Quản trị</a></li>`);
        }
        $('.user-function').append(`<div class="dropdown-divider"></div>`);
        $('.user-function').append(`<li><a class="dropdown-item" href="/Account/Signout">Đăng xuất</a></li>`);
    },
    error: function () { },
    complete: function () { }
})