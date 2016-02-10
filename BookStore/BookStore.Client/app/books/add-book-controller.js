(function() {
    'use script';

    function AddBookController() {
        var vm = this;


    }

    angular.module('bookStoreApp.controllers')
        .controller('AddBookController', ['books', AddBookController]);

}());