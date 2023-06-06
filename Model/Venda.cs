
namespace Game1{

    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }

        public Venda(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
            Produtos = new List<Produto>();
        }
    }


}