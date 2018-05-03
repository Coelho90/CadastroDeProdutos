using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projeto.Infra.Data.Mappings
{
    class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {

            ToTable("Produto");

            HasKey(p => p.IdProduto);

            Property(p => p.IdProduto)
                .HasColumnName("IdProduto")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Preco)
                .HasColumnName("Preco")
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            Property(p => p.DataCompra)
                .HasColumnName("DataCompra")
                .IsRequired();

            Property(p => p.Status)
                .HasColumnName("Status")
                .IsRequired();
        }


    }
}
