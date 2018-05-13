(function () {
    'use strict';

    angular
        .module('app')
        .controller('RoomController', RoomController);

    RoomController.$inject = ['$http', '$location', '$rootScope', 'AccountService', 'FlashService'];
    function RoomController($http, $location, $rootScope, AccountService, FlashService) {
        var vm = this;
        vm.username = AccountService.GetUsername();
        vm.GetRooms = function () {
            return $http.post($rootScope.baseUrl + 'api2/rooms', { UserName: vm.username });
        }
      
    }


})();
