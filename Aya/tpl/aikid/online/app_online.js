(function ($) {
    app.controller('onLine_Ctrl', ['$scope', function ($scope) {
        $scope.title = "待上线奶粉数据";
        $scope.waitupData = null;
        $scope.brands = null;
        $scope.detail = null;
        //点击列表查询详情数据
        $scope.show = function (id) {
            angular.forEach($scope.waitupData, function (flag, _) {
                if (flag._id == id) {
                    $scope.detail = flag;
                    $scope.detail.pictiue =  $scope.detail.pictiue;
                    //从title中筛选出品牌信息
                    angular.forEach($scope.brands, function (brand, _) {
                        if (flag.title.indexOf(brand.name) != -1)
                            $scope.detail.brand = brand.name;
                    })
                }  
            });
            $scope.$apply();
        };
        $scope.addOnLine = function () {
            var r = confirm("是否确认提交!");
            if (r != true) {
                return;
            }
            if (!$scope.detail)
                return;
            var detail = JSON.stringify($scope.detail)
            var data = {
                'context': {
                    "json": detail
                }
            };
            var doajax = doAjax("../../OnLineService/addOnLine", data);
            doajax.done(function (data) {
                $scope.waitupData = data;
                $scope.detail = null;
                $scope.$apply();
            })
        }; 
        $scope.moveOnLine = function () {
            var r = confirm("是否确认商品下架!");
            if (r != true) {
                return;
            }
            if (!$scope.detail)
                return;
            $scope.detail.onLine = false;
            var detail = JSON.stringify($scope.detail)
            var data = {
                'context': {
                    "json": detail
                }
            };
            var doajax = doAjax("../../OnLineService/addOnLine", data);
            doajax.done(function (data) {
                $scope.waitupData = data;
                $scope.detail = null;
                $scope.$apply();
            })
        }; 
        //删除数据
        $scope.deleteOne = function () {
            var r = confirm("是否确认删除!");
            if (r != true) {
                return;
            }
            if (!$scope.detail)
                return;
            var detail = JSON.stringify($scope.detail)
            var data = {
                'context': {
                    "json": detail
                }
            };
            var doajax = doAjax("../../OnLineService/deleteOnLine", data);
            doajax.done(function (data) {
                $scope.waitupData = data;
                $scope.detail = null;
                $scope.$apply();
            })
        };
        var data = {
            'context': {
            }
        };
        var doajax = doAjax("../../OnLineService/obtainAll", data);
        doajax.done(function (data) {
            $scope.waitupData = data;
            $scope.$apply();
        })
        var doajaxBrand = doAjax("../../BrandService/obtainAll", data);
        doajaxBrand.done(function (data) {
            $scope.brands = data;
            $scope.$apply();
        })
    }])
})(jQuery)

