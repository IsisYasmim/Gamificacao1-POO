using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1

{
    public class VendaProduto
    {
        
        public long? Id { get; set; }
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public double Subtotal
        {
            get { return Quantidade * PrecoUnitario; }
        }
      /*public VendaProduto(int id, Produto produto, int quantidade, double precoUnitario)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }*/
    }
}
