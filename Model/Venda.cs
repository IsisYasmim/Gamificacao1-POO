
namespace Game1{

    public class Venda
    {
        public long? Id { get; set; }
        public Guid VendaGuid { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime Data { get; set; }
        public List<VendaProduto>? Produtos { get; set; } = new List<VendaProduto>();
        public static readonly List<Venda> Vendas = new List<Venda>();
        
        // public Venda(int id, Guid vendaGuid, Cliente cliente, DateTime data)
        // {
        //     Id = id;
        //     VendaGuid = vendaGuid;
        //     Cliente = cliente;
        //     Data = data;
        // }
        public double Total
        {
            get
            {//LINQ
                try
                {
                    return Produtos!.Sum(p => p.Subtotal);
                }
                catch (NullReferenceException nrfe)
                {
                    throw new Exception($"Nota sem venda: {nrfe.Message}");
                }
            }
        }
    }


}