(function () {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
    function RegisterController(UserService, $location, $rootScope, FlashService) {
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
                UserService.Register(vm.user)
                    .then(function (response) {
                        if (response.statusText === "OK") {
                            FlashService.Success('Registration successful', true);
                            $location.path('/login');
                        } else {
                            FlashService.Error(response.data);
                            vm.dataLoading = false;
                        }
                    });
            }
        }
    }

})();
