(function () {
	'use strict';

	angular
		.module('app', ['ngRoute', 'ngCookies'])
		.config(function ($provide, $httpProvider, $routeProvider, $locationProvider, $qProvider) {

			// Intercept http calls.
			$provide.factory('MyHttpInterceptor', function () {
				return {
					request: function (config) {
						if (config.url.indexOf('api2') > -1) {
							return config;
						} else if (config.url.indexOf('api') > -1) {
							config.headers = config.headers || {};
							var token = localStorage.getItem('userlogintoken');
							if (token) {
								config.headers.Authorization = 'Bearer ' + token;
							}
							return config;
						}
						return config;
					}

				}
			});

			// Add the interceptor to the $httpProvider.
			$httpProvider.interceptors.push('MyHttpInterceptor');

			$routeProvider
				.when('/login', {
					controller: 'LoginController',
					templateUrl: 'login/login.view.html',
					controllerAs: 'vm'
				})
				.when('/register', {
					controller: 'RegisterController',
					templateUrl: 'register/register.view.html',
					controllerAs: 'vm'
				})
				.when('/home', {
					controller: 'HomeController',
					templateUrl: 'home/home.view.html',
					controllerAs: 'vm'
				})
				.when('/room', {
					controller: 'RoomController',
					templateUrl: 'room/room.view.html',
					controllerAs: 'vm'
				})
				.when('/admin', {
					controller: 'AdminPageController',
					templateUrl: 'adminpage/adminpage.view.html',
					controllerAs: 'vm'
				})
				.when('/add_room', {
					controller: 'AddRoomController',
					templateUrl: 'add_room/add_room.view.html',
					controllerAs: 'vm'
				})
				.when('/list', {
					controller: 'ListRoomsController',
					templateUrl: 'list_rooms/list_rooms.view.html',
					controllerAs: 'vm'
				})
				.otherwise({ redirectTo: '/login' });

		})
		.run(run);

	run.$inject = ['$rootScope', '$location', '$cookies', '$http'];
	function run($rootScope, $location, $cookies, $http) {
		//Base page URL
		$rootScope.baseUrl = "http://localhost/HotelRestaurantAPI/";
	}

})();




//(function () {
//    'use strict';

//    angular
//        .module('app', ['ngRoute', 'ngCookies'])
//        .config(config)
//        .run(run);

//    config.$inject = ['$routeProvider', '$locationProvider'];
//    function config($routeProvider, $locationProvider) {
//        $routeProvider
//            .when('/home', {
//                controller: 'HomeController',
//                templateUrl: 'home/home.view.html',
//                controllerAs: 'vm'
//            })

//            .when('/login', {
//                controller: 'LoginController',
//                templateUrl: 'login/login.view.html',
//                controllerAs: 'vm'
//            })

//            .when('/register', {
//                controller: 'RegisterController',
//                templateUrl: 'register/register.view.html',
//                controllerAs: 'vm'
//            })

//            .otherwise({ redirectTo: '/login' });
//    }

//    run.$inject = ['$rootScope', '$location', '$cookies', '$http'];
//    function run($rootScope, $location, $cookies, $http) {
//        // keep user logged in after page refresh
//        $rootScope.globals = $cookies.getObject('globals') || {};
//        if ($rootScope.globals.currentUser) {
//            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata;
//        }

//        $rootScope.$on('$locationChangeStart', function (event, next, current) {
//            // redirect to login page if not logged in and trying to access a restricted page
//            var restrictedPage = $.inArray($location.path(), ['/login', '/register']) === -1;
//            var loggedIn = $rootScope.globals.currentUser;
//            if (restrictedPage && !loggedIn) {
//                $location.path('/login');
//            }
//        });
//    }

//})();