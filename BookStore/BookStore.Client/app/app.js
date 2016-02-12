(function(parameters) {
    'use sctrict';

    function config($routeProvider, $locationProvider) {

        var PARTIALS_PREFIX = 'views/partials/';
        var CONTROLLER_AS_VIEW_MODEL = 'vm';

        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/', {
                templateUrl: PARTIALS_PREFIX + 'home/index-partial.html',
                controller: 'IndexPartialController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/home', {
                templateUrl: PARTIALS_PREFIX + 'home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/books/add', {
                templateUrl: PARTIALS_PREFIX + 'books/add-book.html',
                controller: 'AddBookController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/books/:id', {
                templateUrl: PARTIALS_PREFIX + 'books/book-details.html',
                controller: 'BookDetailsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/books', {
                templateUrl: PARTIALS_PREFIX + 'books/list-books.html',
                controller: 'BooksController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/identity/register', {
                templateUrl: PARTIALS_PREFIX + 'identity/register.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/identity/login', {
                templateUrl: PARTIALS_PREFIX + 'identity/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/unauthorized', {
                templateUrl: PARTIALS_PREFIX + 'home/unauthorized.html'
            })
            .otherwise({ redirectTo: '/' });
    }

    function run($http, $cookies, auth, notifier) {

        if (auth.isAuthenticated()) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $cookies.get('authentication');
            auth.getIdentity().then(function(identity) {
                notifier.success('Welcome back!');
            });
        }
    };


    angular.module('bookStoreApp.services', []);
    angular.module('bookStoreApp.controllers', ['bookStoreApp.services']);

    angular.module('bookStoreApp', ['ngRoute','ngCookies' , 'bookStoreApp.controllers'])
        .config(['$routeProvider', '$locationProvider', config])
        .run(['$http', '$cookies', 'auth', 'notifier', run])
        .value('toastr', toastr)
        .constant('baseUrl', 'http://localhost:64572/');

}());