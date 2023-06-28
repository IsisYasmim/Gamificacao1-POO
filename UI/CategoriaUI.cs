namespace Game1
{
    public class CategoriaUI
    {   
        public void MenuCategoria()
        {
            string opcaoCat;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar categoria");
                Console.WriteLine("2 - Alterar categoria");
                Console.WriteLine("3 - Listar categorias");
                Console.WriteLine("4 - Ver categoria pelo Id");
                Console.WriteLine("5 - Excluir categoria");
                Console.WriteLine("0 - Sair");
                opcaoCat = Console.ReadLine();


                switch (opcaoCat)
                {
                    case "1":
                        CadastrarCategoria();
                        break;

                    case "2":
                        AlterarCategoria();
                        break;

                    case "3":
                        ListarCategorias();
                        break;

                    case "4":
                        Categoria categoria = BuscarCategoriaPorId();
                        if(categoria != null)
                        {
                            Console.WriteLine($"ID: {categoria.Id} | Guid: {categoria.CategoriaGuid} | Nome: {categoria.Nome} | Descrição: {categoria.Descricao}");
                        }
                        break;

                    case "5":
                        ExcluirCategoria();
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
            } while (opcaoCat != "0");

        }
    
        private void CadastrarCategoria()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de categoria:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            nome = Verificacao.VerificarNulidade(nome);
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            descricao = Verificacao.VerificarNulidade(descricao);
            var proximoId = Categoria.Categorias.Max((e) => e.Id) + 1;
            Categoria categoria = new Categoria
            {
                Id = proximoId ?? 1,
                CategoriaGuid = Guid.NewGuid(),
                Nome = nome,
                Descricao = descricao
            };
            Categoria.Categorias.Add(categoria);


            Console.WriteLine();
            Console.WriteLine("Categoria cadastrada com sucesso!");
        }

        private void AlterarCategoria()
        {
            Console.Clear();

            try
            {
                if (Categoria.Categorias.Count == 0)
                {
                    throw new Exception("Não há nenhuma categoria cadastrada!");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
            Console.WriteLine("Alteração de categoria:");
            Console.Write("Digite o Id da categoria que deseja alterar: ");
            int id = Verificacao.VerificarNumero(Console.ReadLine());
            Categoria categoria = Categoria.Categorias.Find(c => c.Id == id);

           while (categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nDigite novamente o código da categoria: ");
                id = Verificacao.VerificarNumero(Console.ReadLine());
                categoria = Categoria.Categorias.Find(c => c.Id == id);
            }

            Console.Write($"Novo nome para a categoria {categoria.Nome}: ");
            string nome = Console.ReadLine();
            nome = Verificacao.VerificarNulidade(nome);
            categoria.Nome = nome;
            Console.Write($"Nova descrição para a categoria {categoria.Descricao}: ");
            string descricao = Console.ReadLine();
            descricao = Verificacao.VerificarNulidade(descricao);
            categoria.Descricao = descricao;

            Console.WriteLine();
            Console.WriteLine("Categoria alterada com sucesso!");
        }

        private void ListarCategorias()
        {
            Console.Clear();

            try
            {
                if (Categoria.Categorias.Count == 0)
                {
                    throw new Exception("Não há nenhuma categoria cadastrada!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Lista de categorias:");
            foreach (var categoria in Categoria.Categorias)
            {
                Console.WriteLine($"ID: {categoria.Id} | Guid: {categoria.CategoriaGuid} | Nome: {categoria.Nome} | Descrição: {categoria.Descricao}");
            }
        }

        public static Categoria BuscarCategoriaPorId()
        {
            Console.Clear();

            try
            {
                if (Categoria.Categorias.Count == 0)
                {
                    throw new ArgumentException("Não há nenhuma categoria cadastrada!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            Console.WriteLine("Buscar categoria por Id:");

            int id = Verificacao.VerificarNumero(Console.ReadLine());

            Categoria categoria = Categoria.Categorias.Find(c => c.Id == id);

            while (categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nDigite novamente o código da categoria: ");
                id = Verificacao.VerificarNumero(Console.ReadLine());
                categoria = Categoria.Categorias.Find(c => c.Id == id);
            }

            return categoria;

        }

        private void ExcluirCategoria()
        {
            Console.Clear();

            try
            {
                if (Categoria.Categorias.Count == 0)
                {
                    throw new ArgumentException("Não há nenhuma categoria cadastrada!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Exclusão de categoria:");

            int id = Verificacao.VerificarNumero(Console.ReadLine());

            Categoria categoria = Categoria.Categorias.Find(c => c.Id == id);

            while (categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nDigite novamente o código da categoria: ");
                id = Verificacao.VerificarNumero(Console.ReadLine());
                categoria = Categoria.Categorias.Find(c => c.Id == id);
            }

            try
            {
                if (Produto.Produtos.Exists(p => p.Categoria.Id == id))
                {
                    throw new Exception("Não é possível excluir a categoria, pois existem produtos vinculados a ela!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            

            Categoria.Categorias.Remove(categoria);

            Console.WriteLine();
            Console.WriteLine("Categoria excluída com sucesso!");
        }
    }
}
