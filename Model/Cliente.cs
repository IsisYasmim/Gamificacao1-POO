
namespace Game1

{// Arquivo Cliente.cs

    public class Cliente
    {
        public long? Id { get; set; }
        public Guid ClienteGuid { get; set; }
        public string Nome { get; set; } = "";
        public string Sobrenome { get; set; } = "";
        public string Endereco { get; set; } = "";
        public string Telefone { get; set; } = "";
        //public List<Venda> Vendas { get; set; }
        public static readonly List<Cliente> Clientes = new List<Cliente>();

        // public Cliente(int id, Guid clienteGuid, string nome, string sobrenome, string endereco, string telefone)
        // {
        //     Id = id;
        //     ClienteGuid = clienteGuid;
        //     Nome = nome;
        //     Sobrenome = sobrenome;
        //     Endereco = endereco;
        //     Telefone = telefone;
        //     //Vendas = new List<Venda>();
        // }

        // public override string? ToString()
        // {
        //     return $"Id: {Id} | Guid: {ClienteGuid} | Nome: {Nome} {Sobrenome} | Endereço: {Endereco} | Telefone: {Telefone}";
        // }
        // public string NomeCompleto
        // {
        //     get
        //     {
        //         return $"{Nome} {Sobrenome}";
        //     }
        // }
    }

}
