$(document).ready(function () {
    var html = '<div class="col-md-2 focus-grid">'
        + '<a href= "country.html" >'
        + '<div class="focus-border">'
        + '<div class="focus-layout">'
        + '<div class="focus-image"><img width="100" height="100" src="{0}" /></div>'
        + '<h4 class="clrchg">{1}</h4>'
        + '</div>'
        + '</div></a ></div >'; 

    var top = '<div class="col-md-3 biseller-column">'
        + '<a target="_blank" href= "{4}"  >'
        + '<img src="{3}" />'
        + '<span class="price">&#36; {0}</span></a >'
        + '<div class="ad-info">'
        + '<h5>{1}</h5>'
        + '<span>{2}</span></div></div >';
    
    $.ajax({
        type: "GET",
        url: "../json/country.json",
        dataType: "json",
        success: function (data) {
            $(data).each(function (_, flag) {
                var item = html.replace("{0}", flag.icon).replace("{1}", flag.name);
                $(item).appendTo($("#container"));
            })
        }
    });
    var data = {
        'context': {
        }
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(data),
        url: "AikidWebService/obtainRecommend",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var li = "<li >";
            $(data).each(function (_, flag) {
                var item = top.replace("{0}", flag.price).replace("{1}", flag.title)
                    .replace("{2}", flag.createDate).replace("{3}", flag.pictiue)
                    .replace("{4}", flag.url);
                li = li + item;
                if ((_+1) % 4 == 0) {
                    $(li+"</li>").appendTo($("#flexiselDemo3"));
                    li = "<li >";
                }
                
            })

            var length = data.length;
            if (length % 4 != 0)
                $(li + "</li>").appendTo($("#flexiselDemo3"));

            $("#flexiselDemo3").flexisel({
                visibleItems: 1,
                animationSpeed: 2000,
                autoPlay: true,
                autoPlaySpeed: 6000,
                pauseOnHover: true,
                enableResponsiveBreakpoints: true,
                responsiveBreakpoints: {
                    portrait: {
                        changePoint: 480,
                        visibleItems: 1
                    },
                    landscape: {
                        changePoint: 640,
                        visibleItems: 1
                    },
                    tablet: {
                        changePoint: 768,
                        visibleItems: 1
                    }
                }
            });
        }
    });
})