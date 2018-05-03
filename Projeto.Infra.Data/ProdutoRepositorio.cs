using Projeto.Entities;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data
{
    public class ProdutoRepositorio
    {
        public void Insert(Produto p)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(p).State = EntityState.Added;
                d.SaveChanges();
            }

        }

        public void Update(Produto p)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(p).State = EntityState.Modified;
                d.SaveChanges();
            }

        }


        public void Delete(Produto p)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(p).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }


        public List<Produto> FindAll()
        {
            using (DataContext d = new DataContext())
            {
                return d.Produto.ToList();
            }

        }

        public List<Produto> FindByNome(string nome)
        {
            using (DataContext d = new DataContext())
            {
                return d.Produto
                        .Where(p => p.Nome.Contains(nome))
                        .OrderBy(p => p.Nome)
                        .ToList();
            }
        }

        public List<Produto> FindByPreco(decimal precoIni, decimal precoFim)
        {
            using (DataContext d = new DataContext())
            {
                return d.Produto
                        .Where(p => p.Preco >= precoIni && p.Preco <= precoFim)
                        .OrderByDescending(p => p.Preco)
                        .ToList();
            }
        }
    }
}
