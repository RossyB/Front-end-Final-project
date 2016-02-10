(function() {
    'use strict';

    function MainController(auth, identity) {
        var vm = this;

        waitForLogin();

        vm.logout = function () {
            vm.globalySetCurrentUser = undefined;
            auth.logout();
            waitForLogin();
        }

        function waitForLogin() {
            identity.getUser()
            .then(function (user) {
                vm.globalySetCurrentUser = user;
            });
        }
    }

    angular.module('bookStoreApp')
        .controller('MainController', ['auth', 'identity', MainController]);
}());