(function() {
    'use strict';

    function BooksController(books) {
        var vm = this;

        books.getBooks()
            .then(function (indexBooks) {
                vm.Books = indexBooks;
            });

    }

    angular.module('bookStoreApp.controllers')
        .controller('BooksController', ['books', BooksController]);

}());
