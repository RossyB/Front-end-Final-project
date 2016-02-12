(function () {
    'use strict';

    var authService = function authService($http, $q, $cookies, identity, baseUrl) {

        var TOKEN_KEY = 'authentication'; //cookie key 

        var register = function register(user) {

            var defered = $q.defer();

            $http.post(baseUrl + 'api/account/register', user)
                .then(function () {
                    defered.resolve();
                }, function (response) {
                    var error = response.data.ModelState;
                    if (error && error[Object.keys(error)[0]][0]) {
                        error = error[Object.keys(error)[0]][0];
                    } else {
                        error = response.data.message;
                    }

                    defered.reject(error);
                });

            return defered.promise;
        }

        var login = function login(user) {

            var deferred = $q.defer();

            //process data with url encoded format because API expect it this way. 
            var data = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');


            //set header in order to prevent Angular making data to JSON
            $http.post(baseUrl + 'Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (response) {
                    var tokenValue = response.access_token; //token for authorized access

                    //cookie expiration date 
                    var theBigDay = new Date();
                    theBigDay.setHours(theBigDay.getHours() + 72);

                    //save cookie for refresh scenarios
                    $cookies.put(TOKEN_KEY, tokenValue, { expires: theBigDay });

                    //set default authorization header so that we do not need to provise hte header with every request
                    $http.defaults.headers.common.Authorization = 'Bearer ' + tokenValue;

                    getIdentity().then(function () {
                        deferred.resolve(response);
                    });
                })
                .error(function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var getIdentity = function () {

            var deferred = $q.defer();

            $http.get(baseUrl + 'api/account/identity')
                .success(function (identityResponse) {
                    identity.setUser(identityResponse);
                    deferred.resolve(identityResponse);
                });

            return deferred.promise;
        };

        return {
            register: register,
            login: login,
            getIdentity: getIdentity,
            isAuthenticated: function () {
                return !!$cookies.get(TOKEN_KEY);
            },
            logout: function () {
                $cookies.remove(TOKEN_KEY);
                $http.defaults.headers.common.Authorization = null;
                identity.removeUser();
            }
        };
    };

    angular
        .module('bookStoreApp.services')
        .factory('auth', ['$http', '$q', '$cookies', 'identity', 'baseUrl', authService]);
}());