(function() {
    'use strict';

    function data($http, $q, authorization, notifier, baseUrl) {


        function get(url, queryParams) {
            var defered = $q.defer();

            var authheader = authorization.getAuthorizationHeader;

            $http.get(baseUrl + url, { params: queryParams, headers: authheader })
            .then(function (response) {
                    defered.resolve(response.data);
            }, function (error) {
                    notifier.error(error);
                    defered.reject(error);
                });

            return defered.promise;
        }

        function post(url, postData) {
            var defered = $q.defer();

            var authheader = authorization.getAuthorizationHeader;

            $http.post(baseUrl + url, postData, { headers: authheader })
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
        .factory('data', ['$http', '$q', 'authorization', 'notifier', 'baseUrl', data]);
}());