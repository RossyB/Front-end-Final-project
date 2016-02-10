(function() {
    'use strict';

    function books(data) {

        function getBooks() {
            return data.get('api/books');
        }

        function getBooksById(id) {
            return data.get('api/books/' + id);
        }

        return {
            getBooks: getBooks,
            getBooksById: getBooksById
        }
    }

    angular.module('bookStoreApp.services')
        .factory('books', ['data', books]);
}());
