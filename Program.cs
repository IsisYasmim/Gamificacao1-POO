/*  Isis Yasmim Almeida de Sousa
    Guilherme Favero
    Felipe Bueno
*/

using System;
using Produtos;
using Clientes;
using Categorias;
using Vendas;

class Program
{
    public static void Main(string[] args)
    {
        List<Produto> produtos = new List<Produto>();
        List<Categoria> categorias = new List<Categoria>();
        List<Cliente> clientes = new List<Cliente>();
        List<Venda> vendas = new List<Venda>();
        int opcao;
        do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar, remover, ver ou alterar categorias");
                Console.WriteLine("2 - Adicionar, remover, ver ou alterar produtos");
                Console.WriteLine("3 - Adicionar, remover, ver ou alterar clientes");
                Console.WriteLine("4 - Realizar venda");
                Console.WriteLine("0 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CategoriaUI.MenuCategoria(categorias);
                        break;


                    case 2:
                        ProdutoUI.MenuProduto(produtos,categorias);// Código para a opção 2
                        break;


                    case 3:
                        ClienteUI.MenuCliente(clientes, vendas);
                        break;


                    case 4:
                        VendaUI.MenuVenda(produtos, clientes, vendas);
                        break;


                    case 0:
                        Console.WriteLine("Saindo...");
                        break;


                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (opcao != 0);
    
    }
}