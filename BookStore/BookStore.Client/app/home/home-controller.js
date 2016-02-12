(function() {
    'use strict';

    function HomeController() {
        var vm = this,
            rotator = $(".rotator");

        vm.hi = "Welcome to Home page!";

        $(".rotator-wrapper")
            .on("click", ".carousel-control.left", function () {
                rotator.addClass("rotate-left");
            })
            .on("click", ".carousel-control.right", function () {
                rotator.addClass("rotate-right");
            })
            .on("transitionend", function (e) {
                if (e.target == rotator[0]) {
                    if (rotator.is(".rotate-left")) {
                        rotator.removeClass("rotate-left")
                               .children("img:first")
                               .appendTo(rotator);
                    } else {
                        rotator.removeClass("rotate-right")
                               .children("img:last")
                               .prependTo(rotator);
                    }
                }
            });
    }

    angular.module('bookStoreApp.controllers')
        .controller('HomeController', [HomeController]);
}());