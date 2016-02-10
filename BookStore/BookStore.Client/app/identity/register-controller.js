(function() {
    'use strict';

    function RegisterController($location, auth, notifier) {
        var vm = this;

        vm.register = function (user, registerForm)
        {
            if (registerForm.$valid) {
                console.log('...Trying to register user...');
                auth.register(user)
                    .then(function() {
                        notifier.success('Registration successful!');
                        console.log('...User registred...');
                        $location.path('/identity/login');
                    }, function(error) {
                        notifier.error(error);
                    });
            }
        }
    }

    angular.module('bookStoreApp.controllers')
        .controller('RegisterController', ['$location', 'auth', 'notifier', RegisterController]);
}());