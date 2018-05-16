﻿(function () {
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
		vm.months = ["Jan", "Febr", "Márc", "Ápr", "Máj", "Jún", "Júl", "Szept", "Okt", "Nov", "Dec"];

        vm.getOthersBookings = getOthersBookings;

        vm.changeBooking = changeBooking;
        vm.checkDates = checkDates;
        vm.checkDates = checkDate;

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
                $http.post($rootScope.baseUrl + 'api2/otheruserpreservations', { UserName: vm.usernam, filterDate: vm.filterDate });
                console.log(room);
            }
        }
        function getOthersBookings() {
            return $http.post($rootScope.baseUrl + 'api2/otheruserpreservations', { UserName: vm.usernam, filterDate: vm.filterDate });
        }
        vm.getMyBookings = function () {
            return $http.post($rootScope.baseUrl + 'api2/allpreservations', { UserName: vm.username, filterDate: vm.filterDate });
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
