(function () {
	'use strict';

	angular
		.module('app')
		.controller('AdminPageController', AdminPageController);

	AdminPageController.$inject = ['$scope', '$location', '$rootScope', 'AccountService', 'FlashService'];
	function AdminPageController($scope, $location, $rootScope, AccountService, FlashService) {
		var vm = this;
		$scope.langs = [
			{ name: 'Hungarian', abbr: 'HU' },
			{ name: 'Romanian', abbr: 'RO' },
			{ name: 'English (United Kingdom)', abbr: 'EN(GB)' },
		];

		$scope.servs = [
			{ id: 'LNGE', name: 'Shared Lounge' },
			{ id: 'PARK', name: 'Free Parking' },
			{ id: 'REST', name: 'Restaurant' }
		];

		vm.check = check;

		function check() {
			FlashService.Error('Flash Service error on Admin Page!');
		};
	}

})();