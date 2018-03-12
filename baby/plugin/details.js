$(document).ready(function () {
    var span = '<span attr="{1}" class="brand css1">{0}</span>';
    var data = { 'context': {} };
    var brand = "";
    var origin = "";
    $.ajax({
        type: "POST",
        data: JSON.stringify(data),
        url: "AikidWebService/obtainBrand",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            $(data).each(function (_, flag) {
                var item = span.replace("{0}", flag.name).replace("{1}", flag.name);
                $("#d_brand").append($(item));
            })

            $("#d_brand .css1").bind("click", function () {
                $("#d_brand span").removeClass("brand_over");
                $(this).addClass("brand_over");
            })

            $("#d_brand .css1").bind("click", function () {
                brand = $(this).attr("attr");
                if (brand == 0)
                    brand = null;
                searchInfo(brand, origin, 0);
            })


            $("#d_origin .css1").bind("click", function () {
                $("#d_origin span").removeClass("brand_over");
                $(this).addClass("brand_over");
            })
            $("#d_origin .css1").bind("click", function () {
                origin = $(this).attr("attr");
                if (origin == 0)
                    origin = null;
                searchInfo(brand, origin, 0);
            })
        }
    });
    var todyR = '<div class="featured-ad">'
        + '<a href= "{4}" target="_blank" >'
        + '<div class="featured-ad-left">'
        + '<img src="{0}" title="{3}" alt="" />'
        + '</div>'
        + '<div class="featured-ad-right">'
        + '<h4>{1}</h4>'
        + '<p>{2}</p>'
        + '</div>'
        + '<div class="clearfix"></div></a ></div >';
    $.ajax({
        type: "POST",
        data: JSON.stringify(data),
        url: "AikidWebService/obtainRecommend",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var li = "<li >";
            $(data).each(function (_, flag) {
                var item = todyR.replace("{2}", flag.price).replace("{1}", flag.title)
                    .replace("{0}", flag.pictiue).replace("{3}", flag.title)
                    .replace("{4}", flag.url);
                $(item).appendTo($("#top_recommd"))
            })
        }
    });
    searchInfo();
})
function searchInfo(brand, origin, current) {
    var detail = {
        "brand": null,
        "origin": null
    };
    var data = {
        'context': {
            "json": JSON.stringify(detail)
        }
    };
    var list = '<a target="_blank" href="{6}"><li><div style="position:relative">'
        + '<img  src="{1}" title="" alt=""><span class="price">{3}</span>'
        + '<section class="list-left">'
        + '<div style="font-size:12px;height:55px;color:#111" class="title">{2}</div>'
        + '<div style="font-size:14px;color:red;width:100%;text-align:right" class="adprice">{5}</div>'
        + '</section>'
        + ' <section class="list-right">'
        + '</section>'
        + '<div class="clearfix"></div></div></li ></a >';
    current = current || 1;
    var total = 0;
    $.ajax({
        type: "POST",
        data: JSON.stringify(data),
        url: "AikidWebService/obtainBrandNo",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var cachtDate = data;
            if (brand)
                cachtDate = Enumerable.From(cachtDate)
                    .Where(function (x) { return x.brand == brand })
                    .ToArray();
            if (origin)
                cachtDate = Enumerable.From(cachtDate)
                    .Where(function (x) { return x.origin == origin })
                    .ToArray();
            $("#more_detail").empty();
            $(cachtDate).each(function (_, flag) {
                var item = list.replace("{1}", flag.pictiue).replace("{2}", flag.title)
                    .replace("{3}", flag.price).replace("{4}", flag.createDate).replace("{5}", flag.origin)
                    .replace("{6}", flag.url);
                $(item).appendTo($("#more_detail"));
            })

        }
    });
}