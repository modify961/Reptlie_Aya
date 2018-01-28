(function ($) {
    app.controller('agentIp_Ctrl', ['$scope', function ($scope) {
        $scope.title = "代理IP池"
    }])
})(jQuery)
//var data = {
//    'context': {
//    }
//};
//var doajax = doAjax("../../AgentIpService/obtainAll", data);
//doajax.done(function (data) {
//    var t = $('#agentIpList').DataTable({
//        "data": data,
//        pageLength: 100,
//        columns: [
//            { mData: 'ip' },
//            { mData: 'port' },
//            { mData: 'type' },
//            { mData: 'anonymous' },
//            { mData: 'createTime' },
//            { mData: 'checkTime' }
//        ]
//    });
//})
