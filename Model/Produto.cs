using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1

{
    public class Produto
    {
        public long? Id { get; set; }
        public Guid ProdutoGuid { get; set; }
        public string Nome { get; set; } = "";
        public double Preco { get; set; }
        public Categoria? Categoria { get; set; }
        public static readonly List<Produto> Produtos = new List<Produto>();
        // public Produto(int id, Guid produtoGuid, string nome, double preco, Categoria categoria)
        // {
        //     Id = id;
        //     ProdutoGuid = produtoGuid; 
        //     Nome = nome;
        //     Preco = preco;
        //     Categoria = categoria;
        // }
        
        // public override string ToString()
        // {
        //     return $"Id: {Id} | Guid: {ProdutoGuid} | Produto: {Nome} | Preco: {Preco} | Categoria: {Categoria}";
        // }
    }
}
