(function ($) {
    app.controller('waitUp_Ctrl', ['$scope', function ($scope, $rootScope, $modal) {
        $scope.title = "待上线奶粉数据";
        $scope.waitupData = null;
        $scope.brands = null;
        $scope.detail = null;
        //点击列表查询详情数据
        $scope.show = function (id) {
            angular.forEach($scope.waitupData, function (flag, _) {
                if (flag._id == id) {
                    $scope.detail = flag;
                    if ($scope.detail.pictiue.indexOf("aikid360.com:8010")==-1)
                        $scope.detail.pictiue = "https://www.aikid360.com:8010/" + $scope.detail.pictiue;
                    //判断奶粉的段位
                    if (flag.title.indexOf("一段") != -1 || flag.title.indexOf("1段") != -1)
                        $scope.detail.san = "一段";
                    if (flag.title.indexOf("二段") != -1 || flag.title.indexOf("2段") != -1)
                        $scope.detail.san = "二段";
                    if (flag.title.indexOf("三段") != -1 || flag.title.indexOf("3段") != -1)
                        $scope.detail.san = "三段";
                    if (flag.title.indexOf("四段") != -1 || flag.title.indexOf("4段") != -1)
                        $scope.detail.san = "四段";
                    //从title中筛选出品牌信息
                    angular.forEach($scope.brands, function (brand, _) {
                        if (flag.title.indexOf(brand.name) != -1)
                            $scope.detail.brand = brand.name;
                    })
                }  
            });
            $scope.$apply();
        };
        $scope.checkUrl = function () {
            if (!$scope.detail)
                return;
            var detail = JSON.stringify({ "url": $scope.detail.url})
            var data = {
                'context': {
                    "json": detail
                }
            };
            var doajax = doAjax("../../OnLineService/checkExist", data);
            doajax.done(function (data) {
                if (!data) {
                    alert("不存在重复项")
                } else {
                    alert("存在重复项")
                }
            })
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

        //清除数据
        $scope.clearDate = function () {
            $scope.detail = null;
            $scope.$apply();
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
            var doajax = doAjax("../../WaitUpService/deleteWaitUp", data);
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
        var doajax = doAjax("../../WaitUpService/obtainAll", data);
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


    //模态框对应的Controller
    app.controller('modalCtrl', function ($scope, $modalInstance, data) {
        $scope.data = data;

        //在这里处理要进行的操作
        $scope.ok = function () {
            $modalInstance.close();
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }
    });
})(jQuery)

