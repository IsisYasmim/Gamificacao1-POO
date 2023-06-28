namespace Game1
{
    public class RelatorioUI
    {
        public void MostrarRelatorioVendas()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Vendas:");

            try
            {
                if (Venda.Vendas.Count == 0)
                {
                    throw new Exception("Não há nenhuma venda registrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            double totalVendas = 0;

            foreach (var venda in Venda.Vendas)
            {
                Console.WriteLine($"ID da venda: {venda.Id} | Data: {venda.Data} | Cliente: {venda.Cliente.Nome}");

                foreach (var itemVenda in venda.Produtos)
                {
                    Console.WriteLine($"   - Produto: {itemVenda.Produto.Nome} | Quantidade: {itemVenda.Quantidade} | Preço unitário: {itemVenda.PrecoUnitario:C2} | Subtotal: {itemVenda.Subtotal:C2}");
                }

                Console.WriteLine($"   Total da venda: {venda.Total:C2}");
                Console.WriteLine();

                totalVendas += venda.Total;
            }

            Console.WriteLine($"Total de Venda: {Venda.Vendas.Count} | Valor total das Venda: {totalVendas:C2}");

        }
    }

}