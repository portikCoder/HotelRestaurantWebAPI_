(function () {
    'use strict';

    angular
        .module('app')
        .factory('UserService', UserService);    

    UserService.$inject = ['$http'];
    function UserService($http) {
        var service = {};

        service.Login = Login;
        service.Register = Register;

        return service;

        function Login(user) {
            return $http.post('http://localhost/HotelRestaurantAPI/api2/login', { UserName: user.username, Password: user.password });
        }

        function Register(user) {
            return $http.post('http://localhost/HotelRestaurantAPI/api2/signup', { UserName: user.username, Password: user.password });
        }
        
    }

})();
