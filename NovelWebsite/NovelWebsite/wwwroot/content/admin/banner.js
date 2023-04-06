
function AddOrUpdateBanner(id) {
    $.ajax({
        url: "/Admin/banner/AddOrUpdateBanner?id=" + id,
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        success: function (data) {
            $('input[name="BannerId"]').val(data.bannerId);
            $('input[name="bannerImage"]').val(data.bannerImage);
            $('img.input-img').attr("src", data.bannerImage);
        },
        error: function () { },
        complete: function () { }
    })
}

$('img.input-img').on('load', function () {
    $('input[name="bannerImage"]').val(imgPath);
});