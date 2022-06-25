var app = angular.module('myapp', []); //tao 1 module
app.controller('giohangcontroller', function ($scope, $http) {
    

    


    // alert(76);
    $scope.listcartp = JSON.parse(localStorage.getItem('cart'));
    // alert($scope.listcartp[0].tenSP);
//GIO HANG
    $scope.tongtien = 0;

    $scope.tongmathang = 0;

    $scope.LoadCart = function () {

        $scope.tongtien = 0;
      

        $scope.listcartp = JSON.parse(localStorage.getItem('cart'));

        // $scope.listcart.forEach(function (e) {

        //     $scope.tongtien += e.Dongia * e.quantity;

        // })
    }

    if (localStorage.getItem('cart') != null) {

        $scope.LoadCart();

    }



    $scope.tang = function (s) {

        $scope.listcartp3 = JSON.parse(localStorage.getItem('cart'));

        for (let x of $scope.listcartp3) {

            if (x.id_SP == s) {

                x.quantity += 1;

                break;

            }

        }

        localStorage.setItem('cart', JSON.stringify($scope.listcartp3));

        $scope.LoadCart();

    }

    $scope.giam = function (s) {

        $scope.listcartp4 = JSON.parse(localStorage.getItem('cart'));

        for (let x of $scope.listcartp4) {

            if (x.id_SP == s) {

                if (x.quantity == 1) {

                    break;

                }

                else {

                    x.quantity = x.quantity - 1;

                    break;

                }

            }

        }

        localStorage.setItem('cart', JSON.stringify($scope.listcartp4));

        $scope.LoadCart();

    }

    $scope.capnhat = function () {

        $scope.LoadCart();

        // location.reload();

    }

    $scope.xoa = function (s) {

        var i = 0;

        var rslist = JSON.parse(localStorage.getItem('cart'));

        for (let x of rslist) {

            if (x.id_SP == s) {

                rslist.splice(i, 1);

                break;

            }

            i++;

        }

        localStorage.setItem('cart', JSON.stringify(rslist));

        $scope.LoadCart();

        alert("Xoá thành công");

    }

    $scope.xoahet = function () {

        if (localStorage.getItem('cart') != null) {

            localStorage.removeItem('cart');

            alert("đã xoá");

        }

        else {

            alert("Không còn sản phẩm trong giỏ");

        }

    }
});
