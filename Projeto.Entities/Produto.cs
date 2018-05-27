using Projeto.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Produto
    {

        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public Status Status { get; set; }


        public Produto()
        {

        }

        public Produto(int idProduto, string nome, decimal preco, int quantidade, DateTime dataCompra, Status status)
        {
            IdProduto = idProduto;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            DataCompra = dataCompra;
            Status = status;
        }


        public override string ToString()
        {
            return $"Id: {IdProduto}, Nome: {Nome}, Preço: {Preco}, Quantidade: {Quantidade}, Data: {DataCompra}, Status: {Status}";
        }

    }
}
