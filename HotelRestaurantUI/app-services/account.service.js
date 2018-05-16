(function () {
    'use strict';

    angular
        .module('app')
        .factory('AccountService', AccountService);

    AccountService.$inject = ['$http', '$rootScope'];
    function AccountService($http, $rootScope) {
        var service = {};
        var userStatus = "basic-user"
        var username = "";

        // To make them to the public interface
        service.Login = Login;
        service.Register = Register;
        service.LoadUserInterface = LoadUserInterface;
        service.SetUsername = SetUsername;
        service.GetUsername = GetUsername;
        service.SetUserStatus = SetUserStatus;
        service.GetUserStatus = GetUserStatus;
        // To not forget it... 
        service.username = username;

        return service;

        function SetUsername(username) {
            this.username = username;
        }

        function GetUsername() {
            return this.username;
        }

        function SetUserStatus(userStatus) {
            this.userStatus = userStatus;
        }

        function GetUserStatus() {
            return this.userStatus;
        }

        function LoadUserInterface(userstat) {
            userStatus = userstat;
            //////////////////////
            ////// HERE /////////
            ////// We need /////
            ////// To check ///
            ////// Whether ///
            ////// Admin ////
            ////// Or NOT! /
            ////// And to /
            ////// Load //
            ////// The //
            ////// page/
            ///////////
        }

        function setLoadedRoom(room) {
            service.loadedRoom = room;
        }

        function Login(user) {
            return $http.post($rootScope.baseUrl + 'api2/login', { UserName: user.username, Password: user.password });
        }

        function Register(user) {
            //return $http.post($rootScope.baseUrl + 'api2/Account/Register', { Email: user.email, FirstName: user.firstName, LastName: user.lastName, UserName: user.username, Password: user.password, ConfirmPassword: user.confirmPassword });
            return $http.post($rootScope.baseUrl + 'api2/signup', { Email: user.email, FirstName: user.firstName, LastName: user.lastName, UserName: user.username, Password: user.password, ConfirmPassword: user.confirmPassword });
        }

    }

})();