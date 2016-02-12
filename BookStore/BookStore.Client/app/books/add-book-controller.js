(function() {
    'use script';

    function AddBookController($location, categories, books) {
        var vm = this;

        categories.getAll()
            .then(function(allCategories) {
                vm.categories = allCategories;
            });

        vm.addBook = function (newBook) {
            books.createTrip(newBook)
                .then(function (addedBookId) {
                    $location.path('/books/' + addedBookId);
                });
        }
    }

    angular.module('bookStoreApp.controllers')
        .controller('AddBookController', ['$location', 'categories', 'books', AddBookController]);

}());