app.controller(
    'produto-cadastro-controller',
    function ($scope, $http) {

        $scope.produto = {
            Nome: "", Preco: 0, Quantidade: 0, Status: "1"
        }

       
        $scope.cadastrar = function () {

            $scope.mensagem = "Processando requisição, por favor aguarde.";

           
            $http.post('http://localhost:64792/api/produto/cadastrar',
                $scope.produto)
                .then(function (d) { 
                    $scope.mensagem = d.data;

                    
                    $scope.produto = {
                        Nome: "", Preco: 0, Quantidade: 0, Status: "1"
                    }
                })
                .catch(function (e) { 

                    if (e.status == 400) { 

                       
                        $scope.erros = e.data;

                        $scope.mensagem = "";
                    }
                    else {
                        
                        $scope.mensagem = e.data;
                    }
                });
        };
    }
);