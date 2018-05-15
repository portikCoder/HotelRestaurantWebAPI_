(function () {
	'use strict';

	angular
		.module('app')
		.controller('AddRoomController', AddRoomController);

	AddRoomController.$inject = ['$scope', '$location', 'RoomService', 'FlashService'];
	function AddRoomController($scope, $location, RoomService, FlashService) {
		var vm = this;

		vm.check = check;
		vm.newText = "";
		vm.newProp = "";
		vm.newExtra = "";
		vm.dataLoading = false;

		vm.add_conf = add_conf;
		vm.add_extra = add_extra;
		vm.add_prop = add_prop;
		vm.add_room = add_room;

		//vm.rTypes = ['Bedroom', 'Bathroom', 'Kitchen'];

		vm.rTypes = [];
		vm.rSubtypes = [];
		vm.rExtras = [];

		RoomService.AddSubtype(null).then(function (response) {
			vm.rTypes = response.data.subtype;
			vm.rTypes.forEach(function (t) {
				RoomService.AddSubtype(t).then(function (response) {
					vm.rSubtypes[t] = response.data.subtype;
				}, function (response) {
					FlashService.Error('Well... this is weird...');
				});
			});
			vm.rTypes.forEach(function (t) {
				RoomService.AddExtra(t).then(function (response) {
					vm.rExtras[t] = response.data.others;
				}, function (response) {
					FlashService.Error('Well... this is weird...');
				});
			});
		}, function (response) {
			FlashService.Error('Well... this is weird...');
		});

		//vm.rSubtypes = [];
		//vm.rSubtypes.Bedroom = ['1 Single Bed', '1 Double Bed', '1 Bunk Bed', '2 Single Beds', '1 Double Bed + 1 Single Bed', '1 Double Bed + 2 Single Beds', '2 Double Beds', '2 Bunk Beds'];
		//vm.rSubtypes.Bathroom = ['Toilet' ,'Shower Room'];
		//vm.rSubtypes.Kitchen = ['Cookery', 'Diner'];
		
		//vm.rProps = ['Small', 'Medium', 'Large', 'Very Large', 'Extra Large'];

		vm.rProps = [];
		RoomService.AddExtra(null).then(function (response) {
			vm.rProps = response.data.others;
		}, function (response) {
			FlashService.Error('Well... this is weird...');
		});


		//vm.rExtras = [];
		//vm.rExtras.Bedroom = ['Mini Fridge', 'Television', 'Air Conditioning', 'Balcony', 'Wardrobe', 'Coffee Machine'];
		//vm.rExtras.Bathroom = ['Toilet', 'Shower Cabin', 'Sink', 'Bathtub', 'Bidet'];
		//vm.rExtras.Kitchen = ['Oven', 'Microwave', 'Sink', 'Refrigerator'];




		function check() {
			FlashService.Error('Well... this is awkward...');
		};

		function add_conf(subtype) {
			var tboxname = document.getElementById("newconfname");
			subtype.push(tboxname.value);
			tboxname.value = "";
		}

		function add_prop(prop) {
			var tboxname = document.getElementById("newprop");
			prop.push(tboxname.value);
			tboxname.value = "";
		}

		function add_extra(extra) {
			var tboxname = document.getElementById("newextra");
			extra.push(tboxname.value);
			tboxname.value = "";
		}

		function add_room() {
			vm.dataLoading = true;
			RoomService.AddRoom(vm.room)
				.then(function (response) {
					if (response.statusText === "OK") {
						FlashService.Success('New Room added', true);
						$location.path('/admin');
					} else {
						FlashService.Error(response.data);
						vm.dataLoading = false;
					}
				}, function (response) {
					// This is for test purposes, change it later to a nice error message to the CLIENT...
					FlashService.Error(response.data);
					vm.dataLoading = false;
				});
		}
	}

})();