app.controller('listController', function ($scope) {
    $scope.products = ['mleko', 'jablko'];

    $scope.addItem = function () {
        $scope.products.push($scope.newProduct);
        $scope.newProduct = "";
    };

    $scope.removeItem = function (i) {
        $scope.products.splice(i, 1);
    };
});