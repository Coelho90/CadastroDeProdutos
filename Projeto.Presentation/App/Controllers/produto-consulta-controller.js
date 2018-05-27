app.controller(
    'produto-consulta-controller',
    function ($scope, $http) {

        //função para obter os produtos do serviço..
        $scope.consultar = function () {

            $http.get("http://localhost:64792/api/produto/listartodos")
                .then(function (d) {
                    //armazenar a lista obtida..
                    $scope.produtos = d.data;
                })
                .catch(function (e) {
                    $scope.mensagem = e.data;
                });
        };

        //função para buscar 1 produto pelo id..
        $scope.obterporid = function (id) {

            $http.get("http://localhost:64792/api/produto/consultarporid?id=" + id)
                .then(function (d) {
                    //armazenar o produto obtido..
                    $scope.produto = d.data;
                })
                .catch(function (e) {
                    $scope.mensagem = e.data; //mensagem de erro..
                });
        };

        //função para excluir o produto..
        $scope.excluir = function () {

            $http.delete("http://localhost:64792/api/produto/excluir?id=" + $scope.produto.IdProduto)
                .then(function (d) {

                    $scope.mensagem = d.data; //exibir mensagem..

                    //executar a consulta novamente..
                    $scope.consultar();
                })
                .catch(function (e) {
                    $scope.mensagem = e.data;
                });
        };

        //função para atualizar o produto..
        $scope.atualizar = function () {

            var model = {
                IdProduto: $scope.produto.IdProduto,
                Nome: $scope.produto.Nome,
                Preco: $scope.produto.Preco,
                Quantidade: $scope.produto.Quantidade,
                DataCompra: $scope.produto.DataCompra,
                Status: ($scope.produto.Status == "Disponivel" ? 1 :
                    $scope.produto.Status == "Esgotado" ? 2 : 0)
            };

            $http.put("http://localhost:64792/api/produto/atualizar", model)
                .then(function (d) {

                    $scope.mensagem = d.data;

                    $scope.consultar();
                })
                .catch(function (e) {
                    $scope.mensagem = e.data;
                });
        };
    }
);