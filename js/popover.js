var popcontent1 = $('.panel-catalog1').html();

const popover1 = new bootstrap.Popover($('#popover-btn1'), {
    content: popcontent1,
    html: true
});

var popcontent2 = $('.panel-catalog2').html();

const popover2 = new bootstrap.Popover($('#popover-btn2'), {
    content: popcontent2,
    html: true
});

