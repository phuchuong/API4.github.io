var app = angular.module('myapp', ['angularUtils.directives.dirPagination']); //tao 1 module
app.controller('nhacungcapcontroller', function($scope, $http) { //tao 1 controller
    
    $scope.currentPage = 1;
    $scope.pagesize = 5;
    $scope.pageChangeHandler = function(num){
        $scope.curentPage = num;
    }
    //hiển thị
    $http({
        method: "GET",
        url: "https://localhost:44352/api/NhaCungCap/GetNhaCungCap"
    }).then(function(response) {
        console.log(response.data);
        $scope.nhacungcap = response.data;
    });
    //loasd lai trang
    $scope.loadlai = function() {
        $http({
            method: "GET",
            url: "https://localhost:44352/api/NhaCungCap/GetNhaCungCap"
        }).then(function(response) {
            console.log(response.data);
            $scope.nhacungcap = response.data;
        });
    }
    $scope.tatmodal = function() {
        $('#modelId').modal('hide');

    }
    //hiểm thị form sửa và xóa
    $scope.showmodal = function(id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Add new nhà cung cấp";
            if($scope.contain){
              delete $scope.contain;
            }
        } else {
            $scope.modalTitle = "Edit nhà cung cấp";
            $http({
                method: "GET",
                url: "https://localhost:44352/api/NhaCungCap"+ id
            }).then(function(response) {
                $scope.contain = response.data;
            });
        }
        $('#modelId').modal('show');
    }




    //xóa
    $scope.deleteClick = function(id) {
        var hoi = confirm("Ban co muon xoa that khong");
        if (hoi) {
            $http({ 
                method: "DELETE",
                url: "https://localhost:44352/api/NhaCungCap/delete/" + id
            }).then(function(response) {
                $scope.message = response.data;
                $scope.loadlai();
            });
        }
    }

    //lưu khi mình ấn save của thêm và sửa
    $scope.saveData = function() {
        if ($scope.id == 0) { //dang them moi sp
            $http({
                method: "POST",
                url: "https://localhost:44352/api/NhaCungCap/create",
                data: $scope.contain,
                "content-Type": "application/json"
            }).then(function(response) {
                $scope.message = response.data;
                console.log(response.data);
                $scope.loadlai();

            });
        } else { //sua san pham
            $http({
                method: "PUT",
                url: "https://localhost:44352/api/NhaCungCap/" + $scope.id,
                data: $scope.contain,
                "content-Type": "application/json"
            }).then(function(response) {
                $scope.message = response.data;
                console.log(response.data);
                $scope.loadlai();

            });
        }
        $('#modelId').modal('hide');

    }
});