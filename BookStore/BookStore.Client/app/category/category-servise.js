(function() {
    'use strict';

    function categories(data) {

        function getAll() {
            return data.get('api/categories');
        }

        return {
            getAll: getAll
    }
    }

    angular.module('bookStoreApp.services')
        .factory('categories', ['data', categories]);
}());