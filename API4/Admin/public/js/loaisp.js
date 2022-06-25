var app = angular.module('myapp', ['angularUtils.directives.dirPagination']); //tao 1 module
app.controller('loaispcontroller', function($scope, $http) { //tao 1 controller
    
    $scope.currentPage = 1;
    $scope.pagesize = 5;
    $scope.pageChangeHandler = function(num){
        $scope.curentPage = num;
    }
    //hiển thị
    $http({
        method: "GET",
        url: "https://localhost:44352/api/LoaiSPs/GetLoaiSP"
    }).then(function(response) {
        console.log(response.data);
        $scope.loaisp = response.data;
    });
    
    $scope.loadlai = function() {
        $http({
            method: "GET",
            url: "https://localhost:44352/api/LoaiSPs/GetLoaiSP"
        }).then(function(response) {
            console.log(response.data);
            $scope.loaisp = response.data;
        });
    }
    $scope.tatmodal = function() {
        $('#modelId').modal('hide');

    }

    //hiểm thị form sửa và xóa
    $scope.showmodal = function(id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Add new admin";
            if($scope.contain){
              delete $scope.contain;
            }
        } else {
            $scope.modalTitle = "Edit admin";
            console.log(id);
            $http({
                method: "GET",
                url: "https://localhost:44352/api/LoaiSPs/"+ id
            }).then(function(response) {
                $scope.contain = response.data[0];
                console.log($scope.contain);
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
                url: "https://localhost:44352/api/LoaiSPs/delete/" + id
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
                url: "https://localhost:44352/api/LoaiSPs/create",
                data: $scope.contain,
                "content-Type": "application/json"
            }).then(function(response) {
                $scope.message = response.data;
                console.log(response.data);
                $scope.loadlai();

            });
        } else { //sua san pham
            $scope.contain.type="";
            $http({
                method: "PUT",
                url: "https://localhost:44352/api/LoaiSPs/" + $scope.id,
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