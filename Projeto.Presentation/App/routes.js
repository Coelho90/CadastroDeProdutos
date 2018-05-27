
var app = angular.module('appProdutos', ['ngRoute']);


app.config(
    function ($routeProvider) {

        $routeProvider
            .when(
            '/produto/cadastro', 
            {
                templateUrl: '/App/Views/cadastro.html',
                controller: 'produto-cadastro-controller'
            }
            )
            .when(
            '/produto/consulta', 
            {
                templateUrl: '/App/Views/consulta.html',
                controller: 'produto-consulta-controller'
            }
            );
    }
);


app.config(function ($locationProvider) {
    $locationProvider.hashPrefix('');
});