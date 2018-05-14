(function () {
	'use strict';

	angular
		.module('app')
		.factory('RoomService', RoomService);

	RoomService.$inject = ['$http', '$rootScope'];
	function RoomService($http, $rootScope) {
		var service = {};
		var roomName = "";
		var roomType = "";
		var roomSubtype = "";
		var roomSize = "";

		service.GetRoomName = GetRoomName;
		service.SetRoomName = SetRoomName;
		service.GetRoomType = GetRoomType;
		service.SetRoomType = SetRoomType;
		service.GetRoomSubtype = GetRoomSubtype;
		service.SetRoomSubtype = SetRoomSubtype;
		service.GetRoomSize = GetRoomSize;
		service.SetRoomSize = SetRoomSize;

		service.AddRoom = AddRoom;

		return service;

		function GetRoomName() {
			return this.roomName;
		}

		function SetRoomName(roomName) {
			this.roomName = roomName;
		}

		function GetRoomType() {
			return this.roomType;
		}

		function SetRoomType(roomType) {
			this.roomType = roomType;
		}

		function GetRoomSubtype() {
			return this.roomType;
		}

		function SetRoomSubtype(roomSubtype) {
			this.roomSubtype = roomSubtype;
		}

		function GetRoomSize() {
			return this.roomSize;
		}

		function SetRoomSize(roomSize) {
			this.roomSize = roomSize;
		}

		function AddRoom(room) {
			//TODO: get http post address
		}
	}

})();