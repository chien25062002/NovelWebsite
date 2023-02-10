function onClickInfoBtn(el) {
    if($(el).hasClass("selected")){
        $(el).removeClass("selected");
    } else {
        $(el).addClass("selected");
    }
}

// function showMore(el) {
//     if($(el).hasClass("collapser")){
//         $(el).prev().collapse("toggle");
//     }
// }
