$(document).ready(function(){
  $(".rank-box-item-box li a").click(function(){
    $(this).parent().toggleClass("box-active");
  });

  $(".btn-filter").click(function(){
    $(".rank-box-item-box li").removeClass("box-active");
  });
});

