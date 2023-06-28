using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game1{
	public class Categoria{
		public long? Id { get; set; } // propriedade nome mais
		public Guid CategoriaGuid { get; set; }
		public String Nome { get; set; } = "";
		public String Descricao { get; set; } = "";
		public static List<Categoria> Categorias = new List<Categoria>();
		// public Categoria(int id, Guid categoriaGuid, string nome, string descricao)
		// {
		// 	Id = id;
		// 	CategoriaGuid = categoriaGuid;
		// 	Nome = nome;
		// 	Descricao = descricao;
		// }
		
		// public override string ToString()
		// {
		// 	return string.Format($"Id: {Id} | Guid: {CategoriaGuid} | Nome: {Nome} | Descrição: {Descricao}");            
		// }
	}
}