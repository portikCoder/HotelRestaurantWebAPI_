(function () {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['AccountService', '$location', '$rootScope', 'FlashService'];
    function RegisterController(AccountService, $location, $rootScope, FlashService) {
        var vm = this;

        vm.register = register;

        function register() {
            vm.dataLoading = true;
            if (vm.user.confrimPassword != vm.user.password) {
                FlashService.Error("Passwords don`t match");
                vm.user.confrimPassword = '';
                vm.dataLoading = false;
            }
            else {
                AccountService.Register(vm.user)
                    .then(function (response) {
                        if (response.statusText === "OK") {
                            FlashService.Success('Registration successful', true);
                            $location.path('/login');
                        } else {
                            FlashService.Error(response.data);
                            vm.dataLoading = false;
                        }
                    }, function (response) {
                        // This is for test purposes, change it later to a nice error message to the CLIENT...
                        FlashService.Error(response.data);
                        vm.dataLoading = false;
                    });
            }
        }
    }

})();
