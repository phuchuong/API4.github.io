var app = angular.module('myapp', []); //tao 1 module
app.controller('chitietcontroller', function ($scope, $http) {


    var  urlnowv=window.location.href;
    const myArray = urlnowv.split("?idsp=");
    $scope.idsp = myArray[1];
    // alert( $scope.idsp);
        // --------------
        if($scope.idsp>0)
        {
            $http({
                method: "GET",
                url: 'https://localhost:44352/api/SanPham/' + $scope.idsp,
                }).then(function(res) {
                    $scope.containdetailsp = res.data[0];
                    console.log($scope.containdetailsp);
                    document.getElementById("kt2").innerHTML= $scope.containdetailsp.moTaChiTiet;
                    
                })
        }


    $scope.listcartp = JSON.parse(localStorage.getItem('cart'));
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

    $scope.addtocart = function (id_SP, tenSP, hinhAnh2,moTaChiTiet, giaBan, quantity) {

        alert('Đã thêm vào giỏ hàng');

        if (quantity == 1) {

            quantity = 1;

        }

        if (quantity == 2) {

            var a = parseInt(document.getElementById('quantityctsp').value);

            quantity = a;

        }

        let item = { 'id_SP': id_SP, 'tenSP': tenSP, 'hinhAnh2': hinhAnh2,'moTaChiTiet':moTaChiTiet, 'giaBan': giaBan, 'quantity': quantity };

        var list = [];

        if (localStorage.getItem('cart') == null) {

            list = [item];

        } else {

            list = JSON.parse(localStorage.getItem('cart'));

            let ok = true;

            for (let x of list) {

                if (x.id_SP == item.id_SP) {

                    if (quantity > 1) {

                        x.quantity += quantity;

                        ok = false;

                        break;

                    }

                    else {

                        x.quantity += 1;

                        ok = false;

                        break;

                    }

                }

            }

            if (ok) {

                list.push(item);

            }

        }

        localStorage.setItem('cart', JSON.stringify(list));

        window.location="http://127.0.0.1:5501/TT/GioHang/cart.html";

    }

    // $scope.tang = function (s) {

    //     $scope.listcartp3 = JSON.parse(localStorage.getItem('cart'));

    //     for (let x of $scope.listcartp3) {

    //         if (x.id_SP == s) {

    //             x.quantity += 1;

    //             break;

    //         }

    //     }

    //     localStorage.setItem('cart', JSON.stringify($scope.listcartp3));

    //     $scope.LoadCart();

    // }

    // $scope.giam = function (s) {

    //     $scope.listcartp4 = JSON.parse(localStorage.getItem('cart'));

    //     for (let x of $scope.listcartp4) {

    //         if (x.id_SP == s) {

    //             if (x.quantity == 1) {

    //                 break;

    //             }

    //             else {

    //                 x.quantity = x.quantity - 1;

    //                 break;

    //             }

    //         }

    //     }

    //     localStorage.setItem('cart', JSON.stringify($scope.listcartp4));

    //     $scope.LoadCart();

    // }

    // $scope.capnhat = function () {

    //     $scope.LoadCart();

    //     // location.reload();

    // }

    // $scope.xoa = function (s) {

    //     var i = 0;

    //     var rslist = JSON.parse(localStorage.getItem('cart'));

    //     for (let x of rslist) {

    //         if (x.id_SP == s) {

    //             rslist.splice(i, 1);

    //             break;

    //         }

    //         i++;

    //     }

    //     localStorage.setItem('cart', JSON.stringify(rslist));

    //     $scope.LoadCart();

    //     alert("Xoá thành công");

    // }

    // $scope.xoahet = function () {

    //     if (localStorage.getItem('cart') != null) {

    //         localStorage.removeItem('cart');

    //         alert("đã xoá");

    //     }

    //     else {

    //         alert("Không còn sản phẩm trong giỏ");

    //     }

    // }
});
