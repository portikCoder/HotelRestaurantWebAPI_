﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'UserService', 'FlashService'];
    function LoginController($location, UserService, FlashService) {
        var vm = this;

        vm.login = login;

        function login() {
            vm.dataLoading = true;
            UserService.Login({ username: vm.username, password: vm.password }).then(function (response) {
                var token = response.data;
                if (token) {
                    localStorage.setItem('jsgametoken', token);
                    $location.path('/home');
                    vm.dataLoading = false;
                }
            }, function (response) {
                FlashService.Error(response.message);
                vm.dataLoading = false;
            });
        };
    }

})();
