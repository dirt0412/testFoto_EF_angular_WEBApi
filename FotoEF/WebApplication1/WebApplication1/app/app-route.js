
(function () { //IIFE hermetyzacja tego co jest w srodku
    'use static';

    angular.module('app')
        .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {
                       
            $urlRouterProvider.otherwise('/app');// /app/emptyMenu

            $stateProvider
            .state('app', {
                url: '/app',
                templateUrl: 'index.html',
                controller: 'globalController as globalCtrl'
            })
            //.state('main', {
            //    url: '/main',
            //    templateUrl: 'views/main.html',
            //    controller: 'mainController as mainCtrl',
            //    params: { 'statuslogin': 'none' }

            //    })



            //.state('app.emptyMenu', {
            //    url: '/emptyMenu',
            //    templateUrl: 'views/templates/emptyMenu.html'//,
            //    //controller: 'mainController as mainCtrl'
            //})
            //.state('app.adminMenu', {
            //     url: '/adminMenu',
            //     templateUrl: 'views/templates/adminMenu.html',
            //     controller: 'mainController as mainCtrl'

            //})
            //.state('menu1', {
            //    url: '/menu1',
            //    templateUrl: 'views/templates/menu1.html'//,
            //    //controller: 'mainController as mainCtrl'

            //})
            //.state('app.menu2', {
            //    url: '/menu2',
            //    templateUrl: 'views/templates/menu2.html'//,
            //    //controller: 'mainController as mainCtrl'

            //})
            //.state('app.menu3', {
            //    url: '/menu3',
            //    templateUrl: 'views/templates/menu3.html'//,
            //    //controller: 'mainController as mainCtrl'

            //})
            //.state('app.menu4', {
            //    url: '/menu4',
            //    templateUrl: 'views/templates/menu4.html'//,
            //    //controller: 'mainController as mainCtrl'

            //})

            ;

            $locationProvider.html5Mode(true);           

        }]);

})();

//other method route
//angular.module("app", ["ngRoute"])
//.config(function ($routeProvider) {
//    $routeProvider
//    .when("/", {
//        templateUrl: "main.htm"
//    })
//    .when("/red", {
//        templateUrl: "red.htm"
//    })
//    .when("/green", {
//        templateUrl: "green.htm"
//    })
//    .when("/blue", {
//        templateUrl: "blue.htm"
//    });
//});