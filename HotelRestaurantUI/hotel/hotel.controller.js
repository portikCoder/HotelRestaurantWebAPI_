(function () {
	'use strict';

	angular
		.module('app')
		.controller('HotelController', HotelController);

	HotelController.$inject = ['$http', '$location', '$scope', '$compile', '$rootScope', 'AccountService', 'RoomService', 'FlashService'];
	function HotelController($http, $location, $scope, $compile, $rootScope, AccountService, RoomService, FlashService) {
		var vm = this;
		//
		vm.username = AccountService.GetUsername();
		vm.roomEdit = [];

		vm.GetRooms = function () {
			return $http.post($rootScope.baseUrl + 'api2/rooms', { UserName: vm.username });
		}
		///
		vm.addRoom = addRoom;
		vm.roomNumber = 0;
		vm.loadRoooms = loadRoooms;
		vm.booking = {};
		vm.isBooked = isBooked;
		function isBooked(roomId) {
			console.log(roomId);
			if (vm.booking.hasOwnProperty(roomId)) {
				return true;
			}
			return false;
		}
		vm.book = book;
		vm.unBook = unBook;
		function unBook(roomId) {
			console.log(roomId);
			delete vm.booking[roomId];
			console.log(vm.booking);
		}
		function book(roomId) {
			console.log(roomId);
			vm.booking[roomId] = "S";
			console.log(vm.booking);
		}

		//Bence
		vm.rTypes = [];
		vm.rSubtypes = [];
		vm.rExtras = [];

		RoomService.GetSubtypes(null).then(function (response) {
			vm.rTypes = response.data.subtype;
			vm.rTypes.forEach(function (t) {
				RoomService.GetSubtypes(t).then(function (response) {
					vm.rSubtypes[t] = response.data.subtype;
				}, function (response) {
					FlashService.Error('Benadryl Crumplesnatch');
				});
			});
			vm.rTypes.forEach(function (t) {
				RoomService.GetExtras(t).then(function (response) {
					vm.rExtras[t] = response.data.others;
				}, function (response) {
					FlashService.Error('Battlefield Counterstrike');
				});
			});
		}, function (response) {
			FlashService.Error('Benedict Cumberbatch');
		});

		vm.rProps = [];
		RoomService.GetExtras(null).then(function (response) {
			vm.rProps = response.data.others;
		}, function (response) {
			FlashService.Error('Biblical Concubine');
		});

		vm.saveChangesTo = saveChangesTo;
		vm.deleteRoom = deleteRoom;
		//Bence End

		vm.sendBookings = sendBookings;
		function sendBookings() {
			$http.post($rootScope.baseUrl + 'api2/rooms', vm.booking);
		}
		function addRoom(room) {

		}
		function addNewCollepsable(targetDiv, collepsableName) {
			var target = document.getElementById(targetDiv);
			var result = "";
			result += `
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-target="#`+ collepsableName + `">` + collepsableName + `</a>
                            </h4>
                                <button type="button" ng-click="vm.sendBookings()">Send Bookings</button>
                        </div>
                        <div id="`+ collepsableName + `" class="panel-collapse collapse"> 
                        </div>
                    </div>
                </div>`;
			angular.element(target).append($compile(result)($scope));
		}
		function addNewRoomToCollepsable(collepsableName, room) {
			var target = document.getElementById(collepsableName);
			var result = "";

			vm.roomEdit[room.id] = false;

			result += `
				<div class="panel-body">
					<div class="panel-group">
						<div class="panel panel-default">
							<div class="panel-heading">
								<h4 class="panel-title" style="display:inline">
									<a data-toggle="collapse" data-target="#`+ room.id + `">` + room.id + `</a>
								</h4>
								<div style="text-align: right">
									<a class="btn btn-primary" ng-click="vm.roomEdit[` + '\'' + room.id + '\'' + `] = ! vm.roomEdit[` + '\'' + room.id + '\'' + `]">Edit Room</a>
									<a class="btn btn-primary" ng-click="vm.deleteRoom(room)">Delete</a>
								</div>
							</div>

							<div ng-show="! vm.roomEdit[` + '\'' + room.id + '\'' + `]" id="` + room.id + `" class="panel-collapse collapse">
								<div class="panel-body">type:`+ room.type + `</div>
								<div class="panel-body">subtype:`+ room.subtype + `</div>
								<div class="panel-body">price:`+ room.room_price + `</div>
								<div class="panel-body">
									<div class="panel-group">
										<div class="panel panel-default">
											<div class="panel-heading">
												<h4 class="panel-title">
													<a data-toggle="collapse" data-target="#`+ room.id + "_properties" + `">Properties </a>
												</h4>
											</div>
											<div id="`+ room.id + "_properties" + `" class="panel-collapse collapse">
											</div>
										</div>
									</div>

									<div class="panel-group">
										<div class="panel panel-default">
											<div class="panel-heading">
												<h4 class="panel-title">
													<a data-toggle="collapse" data-target="#`+ room.id + "_others" + `">Others</a>
												</h4>
											</div>
											<div id="`+ room.id + "_others" + `" class="panel-collapse collapse">
											</div>
										</div>
									</div>
								</div>
							</div>

							<div ng-show="vm.roomEdit[` + '\'' + room.id + '\'' + `]" id="` + room.id + `" class="panel-collapse">
								<div class="panel-body">
									<label for="roomType">
													Type:
									</label>
									<select name="roomType"
											ng-model="` + room.id + `_type"
											ng-options="t for t in vm.rTypes"
											ng-selected="t == room.type">
									</select>
								</div>
								<div class="panel-body">
									<label for="roomSubtype">
													Subtype:
									</label>
									<select name="roomSubtype"
											ng-model="` + room.id + `_subtype"
											ng-options="st for st in vm.rSubtypes[` + room.id + `_type]"
											ng-selected="st == room.subtype">
									</select>
								</div>
								<div class="panel-body">
									<label for="roomPrice">
													Price:
									</label>
									<input name="roomPrice" type="number" ng-model="` + room.id + `_price" />
								</div>
								<div class="panel-body">
									<div class="panel-group">
										<div class="panel panel-default">
											<div class="panel-heading">
												<h4 class="panel-title">
													Properties
												</h4>
											</div>
											<div id="`+ room.id + "_properties" + `">
												<div class="grid-container">
													<div class="grid-item" ng-repeat="p in vm.rProps">
														<input type="checkbox"
															   name="{{p}}_"
															   id="{{p}}_"
															   ng-model="`+ room.id + "_properties" + `" />
														<label for="{{p}}_">
															{{p}}
														</label>
													</div>
												</div>
											</div>
										</div>
									</div>

									<div class="panel-group">
										<div class="panel panel-default">
											<div class="panel-heading">
												<h4 class="panel-title">
													Others
												</h4>
											</div>
											<div id="`+ room.id + "_others" + `">
												<div class="grid-container">
													<div class="grid-item" ng-repeat="e in vm.rExtras[` + room.id + `_type]">
														<input type="checkbox"
															   name="{{e}}"
															   id="{{e}}"
															   ng-model="`+ room.id + "_others" + `[e]" />
														<label for="{{e}}">
															{{e}}
														</label>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
								<div style="margin: 0 0 1.5em 1.5em">
									<a class="btn btn-primary" ng-click="vm.saveChangesTo(room)">Confirm Changes</a>
									<a class="btn btn-primary" ng-click="vm.roomEdit[` + '\'' + room.id + '\'' + `] = ! vm.roomEdit[` + '\'' + room.id + '\'' + `]">Cancel</a>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>`;
			angular.element(target).append($compile(result)($scope));
			console.log(result);
			addNewPropertiesToRoom(room.id, room.properties);
			addNewOthersToRoom(room.id, room.others);
		}
		function addNewPropertiesToRoom(roomId, properties) {
			for (var i = 0; i < properties.length; ++i) {
				addNewPropertieToRoom(roomId, properties[i]);
			}
		}
		function addNewPropertieToRoom(roomId, propertie) {
			var target = document.getElementById(roomId + "_properties");
			var result = `<div class="panel-body">` + propertie + `</div>`;
			angular.element(target).append($compile(result)($scope));
		}
		function addNewOthersToRoom(roomId, others) {
			for (var i = 0; i < others.length; ++i) {
				addNewOtherToRoom(roomId, others[i]);
			}
		}
		function addNewOtherToRoom(roomId, other) {
			var target = document.getElementById(roomId + "_others");
			var result = `<div class="panel-body">` + other + `</div>`;
			angular.element(target).append($compile(result)($scope));
		}
		function loadRoooms(targetDiv) {
			console.log("loadRooms");
			console.log("Bugos szar");
			console.log("foss");


			var result = vm.GetRooms().then(function (data) {
				var target = document.getElementById(targetDiv);
				localStorage.setItem("rooms", data);
				var result = "";
				addNewCollepsable(targetDiv, "Rooms");
				for (var i = 0; i < data.data.length; ++i) {
					addNewRoomToCollepsable("Rooms", data.data[i]);
				}

			});
		}
		vm.loadRoooms("container");
		return vm;
		// vm.loadRoooms();
        /*
        vm.register = register;
        
        function register() {
            vm.dataLoading = true;
            if (vm.user.confrimPassword != vm.user.password) {
                FlashService.Error("Passwords doesn`t matches");
                vm.user = {};
                vm.dataLoading = false;
            }
            else {
                UserService.Register(vm.user)
                    .then(function (response) {
                        if (response.success) {
                            FlashService.Success('Registration successful', true);
                            $location.path('/login');
                        } else {
                            FlashService.Error(response.message);
                            vm.dataLoading = false;
                        }
                    });
            }
        }
        */

		function saveChangesTo(room) {
			//TODO send changed data
		}

		function deleteRoom(room) {
			//TODO send delete request
		}
	}


})();
