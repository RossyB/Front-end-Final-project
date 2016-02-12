(function() {
    'use strict';

    function BooksController(books, identity) {
        var vm = this;
        vm.identity = identity;

        books.getBooks()
            .then(function (listBooks) {
                vm.Books = listBooks;
            });

    }

    angular.module('bookStoreApp.controllers')
        .controller('BooksController', ['books', 'identity', BooksController]);

}());
