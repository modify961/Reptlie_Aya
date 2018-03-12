(function ($) {
    app.controller('total_Info', ['$scope', function ($scope) {
        $scope.agentIp_Num = "...";
        var data = {
            'context': {
            }
        };
        $scope.test = function () {
            debugger
        }
        var doajax = doAjax("../../AgentIpService/count", data);
        doajax.done(function (data) {
            $scope.agentIp_Num = data;
            $scope.$apply();
        })
        
    }])
})(jQuery)
