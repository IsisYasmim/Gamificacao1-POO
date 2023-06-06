using Vendas;
namespace Clientes

{// Arquivo Cliente.cs

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public List<Venda> Vendas { get; set; }


        public Cliente(int id, string nome, string sobrenome, string endereco, string telefone)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Telefone = telefone;
            Vendas = new List<Venda>();
        }

        public override string? ToString()
        {
            return $"ID: {Id} | Nome: {Nome} {Sobrenome} | Endereço: {Endereco} | Telefone: {Telefone}";
        }
    }

}
