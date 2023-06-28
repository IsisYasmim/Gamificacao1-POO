namespace Game1
{
    public class ProdutoUI
    {
        public void MenuProduto()
        {
            string opcaoPro;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Cadastrar produto");
                Console.WriteLine("2 - Alterar produto");
                Console.WriteLine("3 - Listar produtos");
                Console.WriteLine("4 - Ver produto pelo Id");
                Console.WriteLine("5 - Excluir produto");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                opcaoPro = Console.ReadLine();

                switch (opcaoPro)
                {
                    case "1":
                        CadastrarProduto();
                        break;
                    case "2":
                        AlterarProduto();
                        break;
                    case "3":
                        ListarProdutos();
                        break;
                    case "4":
                        Produto produto = BuscarProdutoPorId();
                        if(produto != null)
                        {
                            Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: {produto.Preco} | Categoria: {produto.Categoria.Nome}");
                        }
                        break;
                    case "5":
                        ExcluirProduto();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcaoPro != "0");
        }

        private void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de produto:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            nome = Verificacao.VerificarNulidade(nome);

            Console.Write("Preço: ");
            double preco = Verificacao.VerificarDouble(Console.ReadLine());
            
            Console.Write("Id da categoria: ");
            int categoriaId = Verificacao.VerificarNumero(Console.ReadLine());

            Categoria categoria = Categoria.Categorias.Find(c => c.Id == categoriaId);

            while(categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nDigite o ID novamente (0 voltar):");
                categoriaId = Verificacao.VerificarNumero(Console.ReadLine());

                if(categoriaId == 0)
                {
                    return;
                }

                categoria = Categoria.Categorias.Find(c => c.Id == categoriaId);
            }

            var proximoID = Produto.Produtos.Max((e) => e.Id) + 1;

            Produto produto = new Produto
            {
                Id = proximoID ?? 1,
                ProdutoGuid = Guid.NewGuid(),
                Nome = nome,
                Preco = preco,
                Categoria = categoria
            };
            Produto.Produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        private void AlterarProduto()
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

            Console.WriteLine("Alteração de produto:");

            Console.Write("ID do produto: ");
            long idProduto = long.Parse(Console.ReadLine());

            Produto produto = Produto.Produtos.Find(p => p.Id == idProduto);

            while(produto == null)
            {
                Console.Write("\nProduto não encontrado!\nInforme o ID novamente:");
                idProduto = int.Parse(Console.ReadLine());
                produto = Produto.Produtos.Find(p => p.Id == idProduto);
            }
            
            Console.Write($"Digite o novo nome ({produto.Nome}): ");
            string nome = Console.ReadLine();
            nome = Verificacao.VerificarNulidade(nome);
            produto.Nome = nome;

            Console.Write($"Digite o novo preço ({produto.Preco}): ");
            double preco = Verificacao.VerificarDouble(Console.ReadLine());
            produto.Preco = preco;

            Console.Write($"Digite o novo id da categoria ({produto.Categoria.Id}): ");
            int categoriaId = Verificacao.VerificarNumero(Console.ReadLine());
            produto.Categoria = Categoria.Categorias.Find(c => c.Id == categoriaId);

            while(produto.Categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nInforme o ID novamente:");
                categoriaId = Verificacao.VerificarNumero(Console.ReadLine());
                produto.Categoria = Categoria.Categorias.Find(c => c.Id == categoriaId);
            }

            Console.WriteLine("Produto alterado com sucesso!");
        }
        
        public static void ListarProdutos()
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

            Console.WriteLine("Lista de produtos:");
            foreach (var produto in Produto.Produtos)
            {
                Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: {produto.Preco} | Categoria: {produto.Categoria.Nome}");
            }
        }

        public static Produto BuscarProdutoPorId()
        {
            Console.Clear();

            try
            {
                if (Produto.Produtos.Count == 0)
                {
                    throw new ArgumentException("Não há nenhum produto cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            Console.WriteLine("Buscar produto por Id:");

            Console.Write("Id do produto: ");
            int id = Verificacao.VerificarNumero(Console.ReadLine());

            Produto produto = Produto.Produtos.Find(c => c.Id == id);

            while (produto == null)
            {
                Console.Write("\nProduto não encontrado!\nDigite novamente o código do produto: ");
                id = Verificacao.VerificarNumero(Console.ReadLine());
                produto = Produto.Produtos.Find(c => c.Id == id);
            }

            return produto;

        }
     
        private void ExcluirProduto()
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

            Console.WriteLine("Exclusão de produto:");

            Console.Write("ID do produto: ");
            int id = Verificacao.VerificarNumero(Console.ReadLine());

            Produto produto = Produto.Produtos.Find(p => p.Id == id);

            if (produto != null)
            {
                Produto.Produtos.Remove(produto);
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }
    }
}
