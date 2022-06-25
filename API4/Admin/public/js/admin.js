var app = angular.module('myapp', ['angularUtils.directives.dirPagination']); //tao 1 module
app.controller('admincontroller', function($scope, $http) { //tao 1 controller
    
    $scope.currentPage = 1;
    $scope.pagesize = 5;
    $scope.pageChangeHandler = function(num){
        $scope.curentPage = num;
    }
    //hiển thị
    $http({
        method: "GET",
        url: "https://localhost:44352/api/NhanVien/GetNhanVien"
    }).then(function(response) {
        console.log(response.data);
        $scope.admin = response.data;
    });
    
    $scope.loadlai = function() {
        $http({
            method: "GET",
            url: "https://localhost:44352/api/NhanVien/GetNhanVien"
        }).then(function(response) {
            console.log(response.data);
            $scope.admin = response.data;
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
                url: "https://localhost:44352/api/NhanVien/"+ id
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
                url: "https://localhost:44352/api/NhanVien/delete/" + id
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
                url: "https://localhost:44352/api/NhanVien/create",
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
                url: "https://localhost:44352/api/NhanVien/" + $scope.id,
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

    // $scope.signIn = function(){
    
    //     $http(
    //         {
    //             method:'GET',
    //             url: '/admin/aaa',
    //             data: $scope.admin
    //         }
    //         ).then(function(res){
    //             if(res.data == "ok"){
    //                 alert(res.data);
    //                 window.location.href = '/admin/sanpham';
    //             }
    //             else{
    //                 alert(res.data);
    //                 alert("Sai tài khoản hoặc mật khẩu");
    //             }
             
    //         });
    //    }
    

});
