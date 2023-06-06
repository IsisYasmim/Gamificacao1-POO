
namespace Game1{
    internal class VendaUI
    {
        public static void AdicionarProdutoPorId(int idProduto, List<Produto> produtosDisponiveis, Venda venda, int quantidade)
        {
            Produto produto = produtosDisponiveis.Find(p => p.Id == idProduto);
            if (produto != null)
            {   
                var vendaProduto = new VendaProduto(0, produto, quantidade, produto.Preco);
                venda.Produtos.Add(vendaProduto);
            }
        }

        public static void RemoverProdutoPorId(int idProduto, Venda venda)
        {
            Produto produto = venda.Produtos.Find(p => p.Id == idProduto);
            if (produto != null)
            {
                var vendaProduto = new VendaProduto(0, produto, quantidade, produto.Preco);
                venda.Produtos.Remove(produto);
            }
        }

        public static void ListarProdutos(Venda venda)
        {
            double total=0;
            Console.WriteLine($"Produtos da venda {venda.Id}:");
            foreach (Produto produto in venda.Produtos)
            {
                Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: R${produto.Preco} | Categoria: {produto.Categoria}");
                total += produto.Preco;
            }
            Console.WriteLine($"Valor total: {total}");

        }

        public static Venda CriarVenda(int id, Cliente cliente)
        {
            Venda venda = new Venda(id, cliente);
            return venda;
        }

        public static void MenuVenda(List<Produto> produtos, List<Cliente> clientes, List<Venda> vendas)
        {
            int opcao;
            int idcli, idvend;
                Console.WriteLine("Insira o ID da venda: ");
                idvend = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Insira o ID do cliente efetuando a compra: ");
                idcli = int.Parse(Console.ReadLine());
                Venda venda = new Venda(idvend, ClienteUI.BuscarClientePorId(idcli,clientes));
                //CriarVenda(idvend, ClienteUI.BuscarClientePorId(idvend,clientes));
            do
            {   
                

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Alterar produto");
                Console.WriteLine("3 - Ver produtos adicionados");
                Console.WriteLine("4 - Terminar venda");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        int id, quantidade;
                        Console.WriteLine("Escreva o ID do produto para adicionar:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva a quantidade: ");
                        quantidade = int.Parse(Console.ReadLine());
                        AdicionarProdutoPorId(id, produtos, venda, quantidade);

                        break;

                    case 2:

                        Console.WriteLine("Escreva o id do produto para remover:");
                        id = int.Parse(Console.ReadLine());
                        RemoverProdutoPorId(id, venda);

                        break;

                    case 3:
                        ListarProdutos(venda);
                        break;

                    case 4:
                        ClienteUI.AdicionarVendas(idcli, vendas, clientes);
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:

                        break;
                }
            } while (opcao != 0 && opcao != 4);




    }
}
}