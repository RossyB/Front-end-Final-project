(function() {
    'use strict';

    function data($http, $q, notifier, baseUrl) {

        function get(url, queryParams) {
            var defered = $q.defer();

            $http.get(baseUrl + url, { params: queryParams })
            .then(function (response) {
                    defered.resolve(response.data);
                }, function(error) {
                    notifier.error(error);
                    defered.reject(error);
                });

            return defered.promise;
        }

        function post(url, postData) {
            var defered = $q.defer();

            $http.post(baseUrl + url, postData)
            .then(function (response) {
                defered.resolve(response.data);
            }, function (error) {
                notifier.error(error);
                defered.reject(error);
            });

            return defered.promise;
        }

        return {
            get: get,
            post: post
    }
    }

    angular.module('bookStoreApp.services')
        .factory('data', ['$http', '$q', 'notifier', 'baseUrl', data]);
}());