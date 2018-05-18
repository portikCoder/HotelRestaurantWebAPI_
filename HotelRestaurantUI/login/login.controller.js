(function () {
	'use strict';

	angular
		.module('app')
		.controller('LoginController', LoginController);

	LoginController.$inject = ['$location', 'AccountService', 'FlashService'];
	function LoginController($location, AccountService, FlashService) {
		var vm = this;

		vm.login = login;

		function login() {
			vm.dataLoading = true;
			AccountService.SetUsername(vm.username);
			AccountService.Login({ username: vm.username, password: vm.password }).then(function (response) {
				var token = response.data.token; //Put breakpoint here for json verification
				var userstatus = response.data.status;
				var username = response.data.username;
				if (token) {
					localStorage.setItem('userlogintoken', token);

					AccountService.SetUserStatus(userstatus);
					AccountService.LoadUserInterface(userstatus);
					vm.dataLoading = false;
                    if (userstatus === "Admin") {
                        $location.path('/admin');
                    } else {
                        $location.path('/hotel');
                    }
				}
			}, function (response) {
				// This is for test purposes, change it later to a nice error message to the CLIENT...
				FlashService.Error(response.data);
				vm.dataLoading = false;
			});
		};
	}

})();
