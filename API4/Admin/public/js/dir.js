
app.run(function ($rootScope) {
    $rootScope.textSearch = "";

    $rootScope.pagination = {
        current: 1
    };
    $rootScope.pageChanged = function(newPage) {
        $rootScope.pagination = {
            current: newPage
        };
    };
})
