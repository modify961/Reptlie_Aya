(function ($) {
    app.controller('country_Ctrl', ['$scope', function ($scope) {
        $scope.brands = null;
        $scope.detail = null;
        $scope.showList = true;  
        $scope.add = function (id) {
            $scope.showList = false;  
        };
        $scope.back = function (id) {
            $scope.showList = true;
        };
        $scope.deleteOne = function (detail) {
            var r = confirm("是否确认删除!");
            if (r != true) {
                return;
            }
            if (!detail)
                detail = JSON.stringify($scope.detail)
            var data = {
                'context': {
                    "json": detail
                }
            };
            var doajax = doAjax("../../BrandService/deleteBrand", data);
            doajax.done(function (data) {
                $scope.showList = true;
                $scope.brands = data;
                $scope.detail = null;
                $scope.$apply();
            })
        };
        $scope.addOne = function (id) {
            if ($scope.detail) {
                if (!$scope.detail.name) {
                    return;
                }
                if (!$scope.detail.conutry) {
                    return;
                }
                if (!$scope.detail.englishName) {
                    return;
                }
                if (!$scope.detail.remark) {
                    return;
                }
                var data = {
                    'context': {
                        "json": JSON.stringify($scope.detail)
                    }
                };
                var doajax = doAjax("../../BrandService/addBrand", data);
                doajax.done(function (data) {
                    $scope.showList = true;  
                    $scope.detail = null;
                    $scope.brands = data;
                    $scope.$apply();
                })
            }
        };
        $scope.edit = function (x) {
            $scope.showList = false;
            $scope.detail = JSON.parse(x);
            $scope.$apply();
        }; 
        var data = {
            'context': {
            }
        };
        var doajax = doAjax("../../BrandService/obtainAll", data);
        doajax.done(function (data) {
            $scope.detail = null;
            $scope.brands = data;
            $scope.$apply();
        })
    }])
})(jQuery)

