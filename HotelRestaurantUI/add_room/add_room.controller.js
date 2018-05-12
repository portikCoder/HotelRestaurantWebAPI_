(function () {
	'use strict';

	angular
		.module('app')
		.controller('AddRoomController', AddRoomController);

	AddRoomController.$inject = ['$location', 'RoomService', 'FlashService'];
	function AddRoomController($location, RoomService, FlashService) {
		var vm = this;

		vm.check = check;		

		function check() {
			FlashService.Error('Kukra fel...');
		};
	}

})();