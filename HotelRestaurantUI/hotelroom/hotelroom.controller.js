(function () {
    'use strict';

    angular
        .module('app')
        .controller('HotelRoomController', HotelRoomController);

    HotelRoomController.$inject = ['$http', '$location', '$rootScope', 'AccountService', 'FlashService'];
    function HotelRoomController($http, $location, $rootScope, AccountService, FlashService) {
        var vm = this;
        //
        vm.username = AccountService.GetUsername();

        vm.GetRooms = function () {
            return $http.post($rootScope.baseUrl + 'api2/rooms', { UserName: vm.username });
        }
        function getRoomById(id) {
            localStorage.clear();
            var temp = JSON.parse(localStorage.getItem("rooms"));
            if (temp === null) {
                var result = vm.GetRooms().then(function (data) {
                    localStorage.setItem("rooms", JSON.stringify(data.data));
                    temp = data.data;
                    console.log(temp);
                    for (var i = 0; i < temp.length; ++i) {
                        console.log(temp[i].id);
                        if (temp[i].id == id) {
                            console.log("talalt");
                            addNewRoomToDiv("container",temp[i]);
                        }
                    }
                    return null;
                });
                return;
              
            }
            console.log(temp);
            for (var i = 0; i < temp.length; ++i) {
                console.log(temp[i].id);
                if (temp[i].id == id) {
                    console.log("talalt");
                    addNewRoomToDiv("container", temp[i]);
                }
            }
            return null;
        }
        function addNewRoomToDiv(divName, room) {
            var target = document.getElementById(divName);
            var result = "";

            result += `
                 <div class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-target="#`+ room.id + `">` + room.id + `</a>
                                </h4>
                            </div>
                            <div id="`+ room.id + `" class="panel-collapse collapse in">
                                <div class="panel-body">type:`+ room.type + `</div>
                                <div class="panel-body">subtype:`+ room.subtype + `</div>
                                <div class="panel-body">
                           
                                  <div class="panel-group">
                                    <div class="panel panel-default">
                                      <div class="panel-heading">
                                        <h4 class="panel-title">
                                          <a data-toggle="collapse" data-target="#`+ room.id + "_properties" + `">Properties </a>
                                        </h4>
                                      </div>
                                      <div id="`+ room.id + "_properties" + `" class="panel-collapse collapse in">
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
                                      <div id="`+ room.id + "_others" + `" class="panel-collapse collapse in">
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
            var result = `<div class="panel-body">` + propertie + `</div>`;
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

        var room_id = "room_404";
        getRoomById(room_id);
      


    }


})();
