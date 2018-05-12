(function () {
	'use strict';

	angular
		.module('app')
		.controller('TopBarController', TopBarController);

	TopBarController.$inject = ['$rootScope', 'AccountService'];
	function TopBarController($rootScope, AccountService) {

		$rootScope.accountService = AccountService;

		$rootScope.logout = function () {

			localStorage.clear();
		}

		$rootScope.hastoken = function () {

			if (localStorage.getItem("userlogintoken") !== null) {
				return true;
			}
		}
	}

})();