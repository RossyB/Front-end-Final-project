(function() {
    'use script';

    function AddBookController($location, notifier, categories, books) {
        var vm = this;

        categories.getAll()
            .then(function(allCategories) {
                vm.categories = allCategories;
            });

        vm.addBook = function (newBook) {
            debugger;
            books.addBook(newBook)
                .then(function (addedBookId) {
                    notifier.success('Book added!');
                    $location.path('/books/' + addedBookId);
                });
        }
    }

    angular.module('bookStoreApp.controllers')
        .controller('AddBookController', ['$location','notifier', 'categories', 'books', AddBookController]);

}());