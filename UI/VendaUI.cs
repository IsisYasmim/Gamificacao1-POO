/*
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
*/








namespace Game1
{
    public class VendaUI
    {
        public void RealizarVenda()
        {
            Console.Clear();

            try
            {
                if (Produto.Produtos.Count == 0)
                {
                    throw new Exception("Não há nenhum produto cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Realizar venda:");

            // Seleciona um cliente existente ou cadastra um novo
            Cliente cliente = SelecionarCliente();

            if(cliente == null)
            {
                return;
            }

            // Cria uma nova venda
            Venda venda = new Venda();
            venda.VendaGuid = Guid.NewGuid();
            venda.Data = DateTime.Now;
            venda.Cliente = cliente;
            var proximoId = Venda.Vendas.Max((v) => v.Id) + 1;
            venda.Id = proximoId ?? 1;

            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Venda nº {venda.Id} - Cliente: {venda.Cliente.Nome}");
                Console.WriteLine();
                ProdutoUI.ListarProdutos();

                Console.WriteLine();
                Console.WriteLine("Digite o ID do produto que deseja comprar (0 para finalizar):");
                int idProduto = Verificacao.VerificarNumero(Console.ReadLine());

                if (idProduto == 0)
                {
                    // Finaliza a venda
                    Venda.Vendas.Add(venda);
                    Console.WriteLine($"Venda finalizada. Total: R${venda.Total}");
                    continuar = false;
                }
                else
                {
                    // Seleciona o produto a ser comprado
                    Produto produto = Produto.Produtos.Find(p => p.Id == idProduto);
                    if (produto == null)
                    {
                        Console.WriteLine("Produto não encontrado!");
                    }
                    else
                    {
                        // Pede a quantidade desejada
                        Console.WriteLine($"Digite a quantidade de {produto.Nome} que deseja comprar:");
                        int quantidade = Verificacao.VerificarNumero(Console.ReadLine());

                        // Adiciona o item à venda
                        var VendaId = venda.Produtos.Max(i => i.Id) + 1;
                        VendaProduto item = new VendaProduto
                        {
                            Id = VendaId ?? 1,
                            Produto = produto,
                            Quantidade = quantidade,
                            PrecoUnitario = produto.Preco
                        };
                        
                        venda.Produtos.Add(item);

                        Console.WriteLine($"{quantidade} X {produto.Nome} adicionado(s) à venda!");

                    }
                }

                Console.WriteLine();
            } while (continuar);
        }

        private Cliente SelecionarCliente()
        {
            Console.Clear();
            Console.WriteLine("Selecione o cliente:");

            foreach (var cliente in Cliente.Clientes)
            {
                Console.WriteLine($"Id: {cliente.Id} | Nome: {cliente.Nome} | Endereço: {cliente.Endereco}");
            }

            Console.Write("Digite o Id do cliente ou 0 para voltar: ");
            int idCliente;
            while (!int.TryParse(Console.ReadLine(), out idCliente) || (idCliente != 0 && !Cliente.Clientes.Exists(c => c.Id == idCliente)))
            {
                Console.WriteLine("Id inválido! Digite novamente...");
                Console.Write("Digite o Id do cliente ou 0 para voltar: ");
            }
            if (idCliente == 0)
            {
                return null;
            }
            else
            {
                return Cliente.Clientes.Find(c => c.Id == idCliente);
            }
        }
    }

}