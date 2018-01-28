var doAjax = function (url, params, contentType) {
    contentType = contentType || "application/json;charset=utf-8";
    var doajax = $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: url,
        dataType: "json",
        contentType: "application/json;charset=utf-8"
    });
    doajax.fail(function () {

        alert("数据交互错误");
    });
    return doajax;
};