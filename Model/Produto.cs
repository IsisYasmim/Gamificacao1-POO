using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categorias;
namespace Produtos

{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Categoria Categoria { get; set; }
        
      public Produto(int id, string nome, double preco, Categoria categoria)

        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = categoria;
        }




        public override string ToString()
        {
            return $"Id: {Id}, Produto: {Nome}, Preco: {Preco}, Categoria: {Categoria}";
        }
    }
}
