(function () {
    'use strict';

    angular
        .module('app')
        .controller('HotelController', HotelController);

    HotelController.$inject = ['$http', '$location', '$rootScope', 'AccountService', 'FlashService'];
    function HotelController($http, $location, $rootScope, AccountService, FlashService) {
        var vm = this;
        //
        vm.username = AccountService.GetUsername();

        vm.GetRooms = function () {
            return $http.post($rootScope.baseUrl + 'api2/rooms', { UserName: vm.username });
        }
        ///
        vm.addRoom = addRoom;
        vm.roomNumber = 0;
        vm.loadRoooms = loadRoooms;
        
        function teszt() {
            console.log("tesztem");
            window.alert();
        }
        vm.teszt = teszt;
        function addRoom(room) {

        }
        function addNewCollepsable(targetDiv,collepsableName) {
                var target = document.getElementById(targetDiv);
                var result = "";
            result += `
                <button ng-click="vm.teszt()">God why</button>
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-target="#`+ collepsableName + `">`+collepsableName+`</a>
                            </h4>
                        </div>
                        <div id="`+ collepsableName+`" class="panel-collapse collapse"> 
                        </div>
                    </div>
                </div>`;
                angular.element(target).append(result);
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
            angular.element(target).append(result);
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
            angular.element(target).append(result);
        }
        function addNewOthersToRoom(roomId, others) {
            for (var i = 0; i < others.length; ++i) {
                addNewOtherToRoom(roomId, others[i]);
            }
        }
        function addNewOtherToRoom(roomId, other) {
            var target = document.getElementById(roomId + "_others");
            var result = `<div class="panel-body">` + other + `</div>`;
            angular.element(target).append(result);
        }
        function loadRoooms(targetDiv) {
            console.log("loadRooms");
            console.log("Bugos szar");
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
