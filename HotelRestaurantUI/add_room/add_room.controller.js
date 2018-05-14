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
		vm.dataLoading = false;

		$scope.add_conf = add_conf;
		$scope.add_room = add_room;

		$scope.rTypes = [
			{ val: 'bedroom', name: 'Bedroom' },
			{ val: 'bathroom', name: 'Bathroom' },
			{ val: 'kitchen', name: 'Kitchen' }
		];

		$scope.rSubtypes = [];
		$scope.rSubtypes.bedroom = [
			{ val: 'single', name: '1 Single Bed' },
			{ val: 'double', name: '1 Double Bed' },
			{ val: 'bunk', name: '1 Bunk Bed' },
			{ val: 'dual-single', name: '2 Single Beds' },
			{ val: 'family-lite', name: '1 Double Bed + 1 Single Bed' },
			{ val: 'family', name: '1 Double Bed + 2 Single Beds' },
			{ val: 'dual-double', name: '2 Double Beds' },
			{ val: 'dual-bunk', name: '2 Bunk Beds' },
		];
		$scope.rSubtypes.bathroom = [
			{ val: 'toilet', name: 'Toilet' },
			{ val: 'shower', name: 'Shower Room' },
		];
		$scope.rSubtypes.kitchen = [
			{ val: 'cookery', name: 'Cookery' },
			{ val: 'diner', name: 'Diner' },
		];

		$scope.rSizes = [
			{ val: 'S', name: 'Small' },
			{ val: 'M', name: 'Medium' },
			{ val: 'L', name: 'Large' },
			{ val: 'XL', name: 'Very Large' },
			{ val: 'XXL', name: 'Extra Large' },
		];

		$scope.rExtras = [];
		$scope.rExtras.bedroom = [
			{ val: 'minifridge', name: 'Mini Fridge' },
			{ val: 'tv', name: 'Television' },
			{ val: 'ac', name: 'Air Conditioning' },
			{ val: 'balcony', name: 'Balcony' },
			{ val: 'wardrobe', name: 'Wardrobe' },
			{ val: 'coffee', name: 'Coffee Machine' }
		];
		$scope.rExtras.bathroom = [
			{ val: 'toilet', name: 'Toilet' },
			{ val: 'shower', name: 'Shower Cabin' },
			{ val: 'sink', name: 'Sink' },
			{ val: 'tub', name: 'Bathtub' },
			{ val: 'bidet', name: 'Bidet' }
		];
		$scope.rExtras.kitchen = [
			{ val: 'oven', name: 'Oven' },
			{ val: 'microwave', name: 'Microwave' },
			{ val: 'sink', name: 'Sink' },
			{ val: 'fridge', name: 'Refrigerator' }
		];

		function check() {
			FlashService.Error('Well... this is awkward...');
		};

		function add_conf(subtype) {
			var tboxval = document.getElementById("newconfval");
			var tboxname = document.getElementById("newconfname");
			subtype.push({ val: tboxval.value, name: tboxname.value });
			tboxval.value = "";
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