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
		var roomProp = "";
		var roomExtra = "";
		var roomPrice = 0;

		service.GetRoomName = GetRoomName;
		service.SetRoomName = SetRoomName;
		service.GetRoomType = GetRoomType;
		service.SetRoomType = SetRoomType;
		service.GetRoomSubtype = GetRoomSubtype;
		service.SetRoomSubtype = SetRoomSubtype;
		service.GetRoomProp = GetRoomProp;
		service.SetRoomProp = SetRoomProp;
		service.GetRoomExtra = GetRoomExtra;
		service.SetRoomExtra = SetRoomExtra;
		service.GetRoomPrice = GetRoomPrice;
		service.SetRoomPrice = SetRoomPrice;

		service.AddRoom = AddRoom;
		service.GetSubtypes = GetSubtypes;
		service.GetExtras = GetExtras;

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

		function GetRoomProp() {
			return this.roomProp;
		}

		function SetRoomProp(roomProp) {
			this.roomProp= roomProp;
		}

		function GetRoomExtra() {
			return this.roomExtra;
		}

		function SetRoomExtra(roomExtra) {
			this.roomExtra = roomExtra;
		}

		function GetRoomPrice() {
			return this.roomPrice;
		}

		function SetRoomPrice(roomPrice) {
			this.roomPrice = roomPrice;
		}

		function AddRoom(room) {
			//TODO: get http post address
		}

		function GetSubtypes(type) {
			return $http.get($rootScope.baseUrl + "api2/subtypes");
		}

		function GetExtras(type) {
			return $http.get($rootScope.baseUrl + "api2/extras");
		}
	}

})();