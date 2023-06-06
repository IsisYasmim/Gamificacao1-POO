
namespace Game1
{
    public class CategoriaUI
    {// Adicionar uma categoria
        public static void AdicionarCategoria(Categoria categoria, List<Categoria> categorias)
        {
            categorias.Add(categoria);
        }


        // Alterar uma categoria com base no ID
        public static void AlterarCategoria(int? id, Categoria categoriaNova, List<Categoria> categorias)
        {
            Categoria categoriaAntiga = categorias.Find(c => c.Id == id);
            if (categoriaAntiga != null)
            {
                categoriaAntiga.Nome = categoriaNova.Nome;
                categoriaAntiga.Descricao = categoriaNova.Descricao;
            }
        }

        // Remover uma categoria com base no ID
        public static void RemoverCategoria(int id, List<Categoria> categorias)
        {
            Categoria categoria = categorias.Find(c => c.Id == id);
            if (categoria != null)
            {
                categorias.Remove(categoria);
                Console.WriteLine("Categoria removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Categoria inexistente");
            }
        }


        public static void ListarCategorias(List<Categoria> categorias)
        {
            foreach (Categoria categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.Id} | Nome: {categoria.Nome} | Descrição: {categoria.Descricao}");
            }
        }

        public static Categoria BuscarCategoriaPorId(int id, List<Categoria> categorias)
        {
            Categoria categoria = categorias.Find(c => c.Id == id);
            return categoria;
        }

        public static void MenuCategoria(List<Categoria> categorias)
        {
            int opcaoCat;
            do
            {

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar categoria");
                Console.WriteLine("2 - Remover categoria");
                Console.WriteLine("3 - Alterar categoria");
                Console.WriteLine("4 - Ver categorias adicionadas");
                Console.WriteLine("5 - Ver categoria específica");
                Console.WriteLine("0 - Sair");
                opcaoCat = int.Parse(Console.ReadLine());


                switch (opcaoCat)
                {
                    case 1:
                        int id;
                        string nome, descricao;
                        Console.WriteLine("Escreva o id da categoria:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o nome da categoria:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Escreva a descrição da categoria:");
                        descricao = Console.ReadLine();
                        Categoria novacategoria = new Categoria(id, nome, descricao);
                        AdicionarCategoria(novacategoria, categorias);

                        break;

                    case 2:

                        Console.WriteLine("Escreva o id da categoria para remover:");
                        id = int.Parse(Console.ReadLine());
                        RemoverCategoria(id, categorias);
                        break;

                    case 3:
                        Console.WriteLine("Escreva o id da categoria a ser alterada:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o nome da categoria nova:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Escreva a descrição da categoria nova:");
                        descricao = Console.ReadLine();
                        Categoria categoriaAlterada = new Categoria(id, nome, descricao);
                        AlterarCategoria(id, categoriaAlterada, categorias);
                        break;

                    case 4:
                        ListarCategorias(categorias);
                        break;

                    case 5:
                        Console.WriteLine("Escreva o id da categoria a ser procurada:");
                        id = int.Parse(Console.ReadLine());
                        BuscarCategoriaPorId(id,categorias);
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:

                        break;
                }
            } while (opcaoCat != 0);

        }
    }
}
