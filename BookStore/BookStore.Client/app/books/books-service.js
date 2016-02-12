(function() {
    'use strict';

    function books(data) {

        function getBooks() {
            return data.get('api/books');
        }

        function getBooksById(id) {
            return data.get('api/books/' + id);
        }

        function addBook(newBook) {
            return data.post('api/books', newBook);
        }

        return {
            getBooks: getBooks,
            getBooksById: getBooksById,
            addBook: addBook
        }
    }

    angular.module('bookStoreApp.services')
        .factory('books', ['data', books]);
}());
