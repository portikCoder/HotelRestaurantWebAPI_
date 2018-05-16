(function () {
    'use strict';

    angular
        .module('app', ['daypilot'])
        .controller('HotelController', HotelController);

    HotelController.$inject = ['$http', '$location', '$scope', '$compile', '$rootScope', 'AccountService', 'FlashService'];
    function HotelController($http, $location, $scope, $compile, $rootScope, AccountService, FlashService) {
        var vm = this;
        vm.date = new Date();
        //
        vm.username = AccountService.GetUsername();

        vm.GetRooms = function () {
            return $http.post($rootScope.baseUrl + 'api2/rooms', { UserName: vm.username });
        }
        ///
        vm.hotelRoomsDivName = "HotelRooms";
        vm.addRoom = addRoom;
        vm.roomNumber = 0;
        vm.loadRoooms = loadRoooms;
        vm.booking = {};
        vm.isBooked = isBooked;
        vm.startDate = [];
        vm.endDate = [];
        vm.checkDate = checkDate;
        vm.checkDates = checkDates;
        vm.filterStartDate;
        vm.filterEndDate;
        vm.filter = filter;
        function filter() {
            if (checkDate(vm.filterStartDate) &&
                checkDate(vm.filterEndDate) &&
                (vm.filterStartDate <= vm.filterEndDate)
            ) {
                var result = vm.GetRooms().then(function (data) {
                    vm.startDate = [];
                    vm.endDate = [];
                    vm.booking = {};

                    var target = document.getElementById(vm.hotelRoomsDivName);
                    target.innerHTML = "";
                   
                    localStorage.setItem("rooms", JSON.stringify(data));
                    var result = "";
                    addNewCollepsable(vm.hotelRoomsDivName, "Rooms");
                    for (var i = 0; i < data.data.length; ++i) {
                        addNewRoomToCollepsable("Rooms", data.data[i]);
                    }

                });
            }
        }
        function checkDates(roomId) {
            return checkDate(vm.startDate[roomId]) && checkDate(vm.endDate[roomId]) && (vm.startDate[roomId] <= vm.endDate[roomId]);
        }

        function checkDate(date) {
            if (date === undefined || date === null) {
                return false;
            }
            var today = new Date();
            if (today > date) {
                return false;
            }
            return true;

        }
        function isBooked(roomId) {
            
            if (vm.booking.hasOwnProperty(roomId)) {
                return true;
            }
            return false;
        }
        vm.book = book;
        vm.unBook = unBook;
        function unBook(roomId) {
          
            delete vm.booking[roomId];
            
        }
        function book(roomId) {
            if (checkDates(roomId)) {
                vm.booking[roomId] = { startDate: vm.startDate[roomId], endDate: vm.endDate[roomId] };
                console.log(vm.booking);
            }
        }
        vm.sendBookings = sendBookings;
        function sendBookings() {
            $http.post($rootScope.baseUrl + 'api2/rooms', vm.booking);
        }
        function addRoom(room) {

        }
        function addNewCollepsable(targetDiv,collepsableName) {
                var target = document.getElementById(targetDiv);
                var result = "";
            result += `
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-target="#`+ collepsableName + `">`+collepsableName+`</a>
                            </h4>
                                <button type="button" ng-click="vm.sendBookings()">Send Bookings</button>
                        </div>
                        <div id="`+ collepsableName+`" class="panel-collapse collapse"> 
                        </div>
                    </div>
                </div>`;
            angular.element(target).append($compile(result)($scope));
        }
        function addNewRoomToCollepsable(collepsableName,room) {
            var target = document.getElementById(collepsableName);
            var result = "";
          
            result += `
                <div class="panel-body">
                    <div class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-target="#`+ room.id + `">` + room.id + `</a>
                                </h4>
                                <p><input type="date" ng-disabled="vm.isBooked(` + '\'' + room.id + '\'' +`)==true" ng-model="vm.startDate[`+ '\'' + room.id + '\'' + `]" value="{{ date | date: 'yyyy/MM/dd' }}" /> </p>
                                <p><input type="date" ng-disabled="vm.isBooked(` + '\'' + room.id + '\'' +`)==true" ng-model="vm.endDate[`+ '\'' + room.id + '\'' + `]" value="{{ date | date: 'yyyy/MM/dd' }}" />  </p>
                                <button type="button" ng-click="vm.book(`+ '\'' + room.id + '\'' + `)" ng-if="vm.isBooked(` + '\'' + room.id + '\'' +`)==false">Book</button>
                                <button type="button" ng-click="vm.unBook(`+ '\'' + room.id + '\'' + `)" ng-if="vm.isBooked(` + '\'' + room.id + '\'' +`)==true">Unbook</button>

                            </div>
                            <div id="`+ room.id + `" class="panel-collapse collapse">
                                <div class="panel-body">type:`+ room.type + `</div>
                                <div class="panel-body">subtype:`+ room.subtype + `</div>
                                <div class="panel-body">
                           
                                  <div class="panel-group">
                                    <div class="panel panel-default">
                                      <div class="panel-heading">
                                        <h4 class="panel-title">
                                          <a data-toggle="collapse" data-target="#`+ room.id + "_properties" +`">Properties </a>
                                        </h4>
                                      </div>
                                      <div id="`+ room.id + "_properties" +`" class="panel-collapse collapse">
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
                                      <div id="`+ room.id + "_others" +`" class="panel-collapse collapse">
                                      </div>
                                    </div>
                                  </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>`;
            angular.element(target).append($compile(result)($scope));
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
            var result = `<div class="panel-body">` + propertie+`</div>`;
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
            var result = vm.GetRooms().then(function (data) {
                var target = document.getElementById(targetDiv);
                localStorage.setItem("rooms", JSON.stringify(data));
                var result = "";
                addNewCollepsable(targetDiv, "Rooms");
                for (var i = 0; i < data.data.length; ++i) {
                    addNewRoomToCollepsable("Rooms", data.data[i]);
                }        
               
            });
        }
        vm.loadRoooms(vm.hotelRoomsDivName);
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

    }


})();
