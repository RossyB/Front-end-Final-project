(function() {
    'use strict';

    function IndexPartialController(books) {
        var vm = this;

        books.getBooks()
            .then(function(indexBooks) {
                vm.indexBooks = indexBooks;
            });

    }

    angular.module('bookStoreApp.controllers')
        .controller('IndexPartialController', ['books', IndexPartialController]);
}());