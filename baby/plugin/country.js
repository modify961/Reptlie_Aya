$(document).ready(function () {
    var li = '<li>{0}</li>';
    var top = '<div><div class="category" >'
        + '<div class="category-img">'
        + '<img  src="{3}" title="image" alt="" /></div>'
        + '<div class="category-info">'
        + '<h4>{0}</h4>'
        + '<span>{1} 个品牌</span>'
        + '</div>'
        + '<div class="clearfix"></div>'
        + '</div >'
        + '<div class="sub-categories">'
        + '<ul>{2}'
        + '<div class="clearfix"></div>'
        + '</ul>'
        +'</div></div >';
    $.ajax({
        type: "GET",
        url: "../json/brand.json",
        dataType: "json",
        success: function (data) {
            $(data).each(function (_, flag) {
                var item = li.replace("{0}", flag.country);
                $(item).appendTo($("#resp-tabs-list"));
                var topitem = top.replace("{0}", flag.country).replace("{3}", flag.icon);
                topitem = topitem.replace("{1}", flag.brand.length);
                var lis = "";
                $(flag.brand).each(function (i,n) {
                    lis = lis + '<li><a href="details.html">' + n.name+'</a></li>' ;
                })
                topitem = topitem.replace("{2}", lis);
                $(topitem).appendTo($("#resp-tabs"));
            })

            $('#parentVerticalTab').easyResponsiveTabs({
                type: 'vertical',
                width: 'auto',
                fit: true,
                closed: 'accordion',
                tabidentify: 'hor_1',
                activate: function (event) {
                    var $tab = $(this);
                    var $info = $('#nested-tabInfo2');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });
        }
    });
})