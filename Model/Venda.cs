
namespace Game1{

    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<VendaProduto>? Produtos { get; set; }
        public DateTime Data { get; set; }

        public Venda(int id, Cliente cliente, DateTime data)
        {
            Id = id;
            Cliente = cliente;
            Data = data;
        }
    }


}