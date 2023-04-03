$(document).on('change', 'input[name="fileUpload"]', function () {
    let formData = new FormData();
    formData.append("file", $(this).prop("files")[0]);
    formData.append("folder", folder);
    $.ajax({
        url: "/Image/UploadFile",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        beforeSend: () => {

        },
        success: res => {
            $('img.category-image').attr("src", res);
            $('input[name="CategoryImage"]').val(res);
        },
        error: error => {
            console.log(error);
        }
    })
});