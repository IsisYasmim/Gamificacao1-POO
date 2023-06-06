using Produtos;
using Categorias;
namespace Produtos
{
    public class ProdutoUI
    {

        public static void RegistrarProduto(Produto produto, List<Produto> produtos)
        {
            produtos.Add(produto);
        }

        public static void ListarProdutos(List<Produto> produtos)
        {
            foreach (Produto produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public static void RemoverProduto(int id, List<Produto> produtos)
        {
            Produto produto = produtos.Find(p => p.Id == id);
            if (produto != null)
            {
                produtos.Remove(produto);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        public static void AlterarProduto(int id, Produto produtoNovo, List<Produto> produtos)
        {
            Produto produtoAntigo = produtos.Find(c => c.Id == id);
            if (produtoAntigo != null)
            {
                produtoAntigo.Nome = produtoNovo.Nome;
                produtoAntigo.Preco = produtoNovo.Preco;
            }
        }

        public static Produto BuscarProdutoPorId(int id, List<Produto> produtos)
        {
            Produto produto = produtos.Find(c => c.Id == id);
            return produto;
        }

        public static void MenuProduto(List<Produto> produtos, List<Categoria> categorias)
        {
            int opcao;
            do
            {

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Remover produto");
                Console.WriteLine("3 - Alterar produto");
                Console.WriteLine("4 - Ver produtos adicionados");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        int id, idcat;
                        string nome;
                        double preco;
                        Console.WriteLine("Escreva o ID do produto:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o nome do produto:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Escreva o preço do produto:");
                        preco = double.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o ID da categoria do produto:");
                        idcat = int.Parse(Console.ReadLine());
                        Produto novoproduto = new Produto(id, nome, preco, CategoriaUI.BuscarCategoriaPorId(idcat, categorias));
                        ProdutoUI.RegistrarProduto(novoproduto, produtos);

                        break;

                    case 2:

                        Console.WriteLine("Escreva o id do produto para remover:");
                        id = int.Parse(Console.ReadLine());
                        RemoverProduto(id, produtos);

                        break;

                    case 3:
                        Console.WriteLine("Escreva o ID do produto a ser alterado:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o nome do produto novo:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Escreva o preço do produto novo:");
                        preco = double.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o ID da categoria do produto novo:");
                        idcat = int.Parse(Console.ReadLine());
                        Produto produtoAlterado = new Produto(id, nome, preco, CategoriaUI.BuscarCategoriaPorId(idcat, categorias));
                        AlterarProduto(id, produtoAlterado, produtos);

                        break;

                    case 4:
                        ListarProdutos(produtos);
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:

                        break;
                }
            } while (opcao != 0);


        }
    }
}