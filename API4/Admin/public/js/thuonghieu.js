var app = angular.module('myapp', ['angularUtils.directives.dirPagination']); //tao 1 module
app.controller('thuonghieucontroller', function($scope, $http) { //tao 1 controller
    
    $scope.currentPage = 1;
    $scope.pagesize = 5;
    $scope.pageChangeHandler = function(num){
        $scope.curentPage = num;
    }
    //hiển thị
    $http({
        method: "GET",
        url: "https://localhost:44352/api/ThuongHieu/GetThuongHieu"
    }).then(function(response) {
        console.log(response.data);
        $scope.thuonghieu = response.data;
    });
    //loasd lai trang
    $scope.loadlai = function() {
        $http({
            method: "GET",
            url: "https://localhost:44352/api/ThuongHieu/GetThuongHieu"
        }).then(function(response) {
            console.log(response.data);
            $scope.thuonghieu = response.data;
        });
    }
    $scope.tatmodal = function() {
        $('#modelId').modal('hide');

    }
    //hiểm thị form sửa và xóa
    $scope.showmodal = function(id) {
        $scope.id = id;
        if (id == 0) {
            $scope.modalTitle = "Add new sản phẩm";
            if($scope.contain){
              delete $scope.contain;
            }
        } else {
            $scope.modalTitle = "Edit sản phẩm";
            $http({
                method: "GET",
                url: "https://localhost:44352/api/ThuongHieu/"+ id
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
                url: "https://localhost:44352/api/ThuongHieu/delete/" + id
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
                url: "https://localhost:44352/api/ThuongHieu",
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
                url: "https://localhost:44352/api/ThuongHieu/" + $scope.id,
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
    $scope.emptyImage = function () {
        $scope.contain.imageName = '';
        $scope.contain.dataImage = '';
        $scope.stepsModel = [];

    }

    $scope.imageUpload = function (event) {
        var files = event.target.files;

        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            var reader = new FileReader();
            reader.onload = $scope.imageIsLoaded;
            reader.readAsDataURL(file);
            $scope.contain.imageName = file.name;
            console.log($scope.contain.imageName);
        }
    }

    $scope.imageIsLoaded = function (e) {
        $scope.$apply(function () {
          $scope.stepsModel = [];

            $scope.stepsModel.push(e.target.result);
            $scope.contain.dataImage = e.target.result;
            console.log($scope.contain.dataImage);
        });
    }
});