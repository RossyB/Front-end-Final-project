(function() {
    'use strict';

    function LoginController($location, auth, notifier) {
        var vm = this;

        vm.login = function(user, loginForm) {
            if (loginForm.$valid) {
                console.log('...Trying to login user...');
                auth.login(user)
                .then(function () {
                    notifier.success('Login successful!');
                        console.log('...User logged in...');
                        $location.path('/');
                    });
            }
        }
    }

    angular.module('bookStoreApp.controllers')
        .controller('LoginController', ['$location', 'auth', 'notifier', LoginController]);

}());