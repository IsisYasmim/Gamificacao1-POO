/*  Isis Yasmim Almeida de Sousa
    Guilherme Favero
    Felipe Bueno
*/

namespace Game1
{
    public class Program
    {

        static void Main(string[] args)
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Gerenciar produtos");
                Console.WriteLine("2 - Gerenciar categorias");
                Console.WriteLine("3 - Gerenciar clientes");
                Console.WriteLine("4 - Realizar venda");
                Console.WriteLine("5 - Mostrar relatório de vendas");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ProdutoUI produtoUI = new();
                        produtoUI.MenuProduto();
                        break;
                    case "2":
                        CategoriaUI categoriaUI = new();
                        categoriaUI.MenuCategoria();
                        break;
                    case "3":
                        ClienteUI clienteUI = new();
                        clienteUI.MenuCliente();
                        break;
                    case "4":
                        VendaUI vendaUI = new();
                        vendaUI.RealizarVenda();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "5":
                        RelatorioUI relatorioUI = new();
                        relatorioUI.MostrarRelatorioVendas();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                } 
            } while (opcao != "0");
        }
    }
}