(function () {
    'use strict';

    angular
        .module('app', ['daypilot'])
        .controller('BookingsController', BookingsController);

    BookingsController.$inject = ['$http', '$location', '$scope', '$compile', '$rootScope', 'AccountService', 'FlashService'];
    function BookingsController($http, $location, $scope, $compile, $rootScope, AccountService, FlashService) {
        var vm = this;
        vm.date = new Date();
        //
        vm.username = AccountService.GetUsername();

        vm.GetRooms = function () {
            return $http.post($rootScope.baseUrl + 'api2/rooms', { UserName: vm.username });
        }
        ///
        

    }


})();
