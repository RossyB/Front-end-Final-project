(function() {
    'use strict';

    function BookDetailsController( $routeParams, books) {
        var vm = this;

        books.getBooksById($routeParams.id)
            .then(function (responseBook) {
                vm.book = responseBook;
            });
    }

    angular.module('bookStoreApp.controllers')
        .controller('BookDetailsController', ['$routeParams', 'books', BookDetailsController]);

}());