(function () {
    'use strict';

    angular
        .module('app')
        .controller('BookingsController', BookingsController);

    BookingsController.$inject = ['$http', '$location', '$scope', '$compile', '$rootScope', 'AccountService', 'FlashService'];
    function BookingsController($http, $location, $scope, $compile, $rootScope, AccountService, FlashService) {
        var vm = this;
        vm.myBookings=[];
        vm.othersBookings = [];
        vm.filterDate = new Date();
        //
        vm.username = AccountService.GetUsername();

        vm.getOthersBookings = getOthersBookings;

        vm.changeBooking = changeBooking;
        vm.checkDates = checkDates;
        vm.checkDates = checkDate;
        vm.deleteBooking = deleteBooking;
        function deleteBooking(room) {
            //TODO 
            $http.post($rootScope.baseUrl + 'api2/deleteBooking', { UserName: vm.username, booking: room }).then(function (data) {
                if (data.data.result == "ok") {
                    for (var i = 0; i < vm.myBookings.length; ++i) {
                        if (room.id == vm.myBookings[i].id && room.startDate == vm.myBookings[i].startDate && room.endDate == vm.myBookings[i].endDate) {
                            delete vm.myBookings[i];
                            return;
                        }
                    }
                }
            });
        }

        function checkDates(room) {
            return checkDate(room.startDate) && checkDate(room.endDate) && (room.startDate <= room.endDate);
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
        function changeBooking(room) {
          
            if (checkDates(room)) {
                //TODO 
                $http.post($rootScope.baseUrl + 'api2/changeBooking', { UserName: vm.username, booking: room });
                console.log(room);
            }
        }
        function getOthersBookings() {
            return $http.post($rootScope.baseUrl + 'api2/otheruserpreservations', { UserName: vm.username, filterDate: vm.filterDate });
        }
        vm.getMyBookings = function () {
            return $http.post($rootScope.baseUrl + 'api2/userpreservations', { UserName: vm.username, filterDate: vm.filterDate });
        }
        vm.getBookings = getBookings;
        function getBookings() {
            vm.getOthersBookings().then(function (data) {
                vm.othersBookings = data.data;
                for (var i = 0; i < vm.othersBookings.length; ++i) {
                    vm.othersBookings[i].startDate = new Date(vm.othersBookings[i].startDate);
                    vm.othersBookings[i].endDate = new Date(vm.othersBookings[i].endDate);
                }
                console.log(vm.othersBookings);
                vm.getMyBookings().then(function (data) {
                    vm.myBookings = data.data;
                    console.log(vm.myBookings);
                    for (var i = 0; i < vm.myBookings.length; ++i) {
                        vm.myBookings[i].startDate = new Date(vm.myBookings[i].startDate);
                        vm.myBookings[i].endDate = new Date(vm.myBookings[i].endDate);
                        switch (vm.myBookings[i].status) {
                            case 0: {
                                vm.myBookings[i].status = "Pending";
                                break;
                            }
                            case 1: {
                                vm.myBookings[i].status = "Approved";
                                break;
                            }
                        }
                    }
                    console.log(vm.myBookings);
                    
                });
                
            });

        }
        vm.getBookings();
        return vm;
        
        ///
        

    }


})();
