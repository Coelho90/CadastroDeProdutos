using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class ProdutoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o preco do produto.")]
        [Range(1,99999, ErrorMessage = "Informe um preço entre {1} e {2}.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        [Range(1, 99999, ErrorMessage = "Informe a quantidade entre {1} e {2}.")]
        public int Quantidade { get; set; }


        [Required(ErrorMessage = "Informe o status do produto.")]
        [Range(1, 2, ErrorMessage = "Informe um status entre {1} e {2}.")]
        public int Status { get; set; }
    }
}