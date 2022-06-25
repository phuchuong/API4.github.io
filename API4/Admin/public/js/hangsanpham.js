var app = angular.module('myapp', []); //tao 1 module
app.controller('hangcontroller', function ($scope, $http) {


    var  urlnowv=window.location.href;
    const myArray = urlnowv.split("?idloaisp=");

    $scope.idloaisp = myArray[1];
        // --------------
        if($scope.idloaisp>0)
        {
            $http({
                method: "GET",
                url: 'https://localhost:44352/api/SanPham/loaisp/' + $scope.idloaisp,
                }).then(function(res) {
                    $scope.containspbyidlsp = res.data;
                })
                
        }
        
});
