(function () {
	'use strict';

	angular
		.module('app')
		.factory('RoomService', RoomService);

	RoomService.$inject = ['$http', '$rootscope'];
	function RoomService($http, $rootscope) {
		var service = {};
		var roomNo = -1;
		var noOfBeds = -1;

		service.GetRoomNumber = GetRoomNumber;
		service.SetRoomNumber = SetRoomNumber;
		service.GetNumberOfBeds = GetNumberOfBeds;
		service.SetNumberOfBeds = SetNumberOfBeds;

		return service;

		function GetRoomNumber() {
			return this.roomNo;
		}

		function SetRoomNumber(roomNo) {
			this.roomNo = roomNo;
		}

		function GetNumberOfBeds() {
			return this.noOfBeds;
		}

		function SetNumberOfBeds(noOfBeds) {
			this.noOfBeds = noOfBeds;
		}
	}

})();