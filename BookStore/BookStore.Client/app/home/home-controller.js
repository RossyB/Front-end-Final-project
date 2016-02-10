(function() {
    'use strict';

    function HomeController() {
        var vm = this;

        vm.hi = "Welcome to Home page!";

    }

    angular.module('bookStoreApp.controllers')
        .controller('HomeController', [HomeController]);
}());