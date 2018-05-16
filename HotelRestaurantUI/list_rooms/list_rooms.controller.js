(function () {
	'use strict';

	angular
		.module('app')
		.controller('ListRoomsController', ListRoomsController);

	ListRoomsController.$inject = ['$location', 'UserService', 'FlashService'];
	function ListRoomsController($location, UserService, FlashService) {
		var vm = this;

		vm.check = check;

		function check() {
			FlashService.Error('Kukra fel...');
		};
	}

})();