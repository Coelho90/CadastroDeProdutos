﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace Projeto.Services.Models
{
    public class ProdutoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        [Range(1, 99999, ErrorMessage = "Informe um preço entre {1} e {2}.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        [Range(1, 9999, ErrorMessage = "Informe a quantidade entre {1} e {2}.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o Status do produto.")]
        [Range(1, 2, ErrorMessage = "Informe um status entre {1} e {2}.")]
        public int Status { get; set; }
    }
}