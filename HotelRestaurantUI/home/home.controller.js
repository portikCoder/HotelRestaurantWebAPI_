﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$http', '$location', '$rootScope','AccountService', 'FlashService'];
    function HomeController($http, $location, $rootScope, AccountService, FlashService) {
        var vm = this;

        vm.check = check;
        vm.username = AccountService.GetUsername();

		vm.GetRooms = function () {
			return $http.post($rootScope.baseUrl + 'api2/rooms', { UserName: vm.username });
		}
		var result = vm.GetRooms().then(function (data) {
			var temp = data;
			console.log(temp.data);
		});

        function check() {
            FlashService.Error('Kukra fel...');
        };

        /* Setting up the Global`s global user service scope */
        //$scope.userService = UserService;
    }

})();



//(function () {
//    'use strict';

//    angular
//        .module('app')
//        .controller('HomeController', HomeController);

//    HomeController.$inject = ['UserService', '$rootScope'];
//    function HomeController(UserService, $rootScope) {
//        var vm = this;

//        vm.user = null;
//        vm.allUsers = [];
//        vm.deleteUser = deleteUser;

//        initController();

//        function initController() {
//            loadCurrentUser();
//            //loadAllUsers();
//        }

//        function loadCurrentUser() {
//            UserService.GetByUsername($rootScope.globals.currentUser.username)
//                .then(function (user) {
//                    vm.user = user;
//                });
//        }

//        function loadAllUsers() {
//            UserService.GetAll()
//                .then(function (users) {
//                    vm.allUsers = users;
//                });
//        }

//        function deleteUser(id) {
//            UserService.Delete(id)
//                .then(function () {
//                    loadAllUsers();
//                });
//        }
//    }

//})();