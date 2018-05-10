(function () {
	'use strict';

	angular
		.module('app', ['ngRoute', 'ngCookies'])
		.config(function ($routeProvider) {
			$routeProvider
				.when('/add_room', {
					controller: 'AddRoomController',
					templateUrl: 'adminpage/add_room/add_room.view.html',
					controllerAs: 'vm'
				})
				.when('/list', {
					controller: 'ListRoomsController',
					templateUrl: 'adminpage/list_rooms/list_rooms.view.html',
					controllerAs: 'vm'
				});
		})
		.controller('AdminPageController', AdminPageController);

	AdminPageController.$inject = ['$location', '$rootScope', 'UserService', 'FlashService'];
	function AdminPageController($location, $rootScope, UserService, FlashService) {
		var vm = this;

		vm.check = check;
		UserService.GetByUsername($rootScope.globals.currentUser.username)
			.then(function (user) {
				vm.user = user;
			});

		function check() {
			FlashService.Error('Flash Service error on Admin Page!');
		};
	}

})();