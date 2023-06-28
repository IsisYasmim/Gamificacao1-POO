namespace Game1
{
    public class ClienteUI
    {   
        public void MenuCliente()
        {
            string opcaoCli;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Alterar cliente");
                Console.WriteLine("3 - Listar clientes");
                Console.WriteLine("4 - Ver cliente pelo Id");
                Console.WriteLine("5 - Excluir cliente");
                Console.WriteLine("0 - Sair");
                opcaoCli = Console.ReadLine();


                switch (opcaoCli)
                {
                    case "1":
                        CadastrarCliente();
                        break;

                    case "2":
                        AlterarCliente();
                        break;

                    case "3":
                        ListarClientes();
                        break;

                    case "4":
                        Cliente cliente = BuscarClientePorId();
                        if(cliente != null)
                        {
                            Console.WriteLine($"Id: {cliente.Id} | Guid: {cliente.ClienteGuid} | Nome completo: {cliente.Nome} {cliente.Sobrenome} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
                        }
                        break;

                    case "5":
                        ExcluirCliente();
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
            } while (opcaoCli != "0");

        }
    
        private void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de cliente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            nome = Verificacao.VerificarNulidade(nome);

            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();
            sobrenome = Verificacao.VerificarNulidade(sobrenome);

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            endereco = Verificacao.VerificarNulidade(endereco);

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            telefone = Verificacao.VerificarNulidade(telefone);

            var proximoID = Cliente.Clientes.Max((e) => e.Id) + 1;

            Cliente cliente = new Cliente
            {
                Id = proximoID ?? 1,
                ClienteGuid = Guid.NewGuid(),
                Nome = nome,
                Sobrenome = sobrenome,
                Endereco = endereco,
                Telefone = telefone
            };
            Cliente.Clientes.Add(cliente);
            Console.WriteLine("\r\nCliente cadastrado com sucesso!");
        }

        private void AlterarCliente()
        {
            Console.Clear();

            try
            {
                if (Cliente.Clientes.Count == 0)
                {
                    throw new Exception("Não há nenhum cliente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Alterar cliente");

            Console.Write("ID do cliente: ");
            int id = Verificacao.VerificarNumero(Console.ReadLine());

            Cliente cliente = Cliente.Clientes.Find(c => c.Id == id);

            while (cliente == null)
            {
                Console.Write("\nCliente não encontrada!\nDigite novamente o código do cliente: ");
                id = Verificacao.VerificarNumero(Console.ReadLine());
                cliente = Cliente.Clientes.Find(c => c.Id == id);
            }

            Console.Write($"Digite o novo nome ({cliente.Nome}): ");
            string nome = Console.ReadLine();
            nome = Verificacao.VerificarNulidade(nome);

            Console.Write($"Digite o novo sobrenome ({cliente.Sobrenome}): ");
            string sobrenome = Console.ReadLine();
            sobrenome = Verificacao.VerificarNulidade(sobrenome);

            Console.Write($"Digite o novo endereço ({cliente.Endereco}): ");
            string endereco = Console.ReadLine();
            endereco = Verificacao.VerificarNulidade(endereco);

            Console.Write($"Digite o novo telefone ({cliente.Telefone}): ");
            string telefone = Console.ReadLine();
            telefone = Verificacao.VerificarNulidade(telefone);

            cliente.Nome = nome;
            cliente.Sobrenome = sobrenome;
            cliente.Endereco = endereco;
            cliente.Telefone = telefone;
            Console.WriteLine("Cliente alterado com sucesso!");
        }

        private void ListarClientes()
        {
            Console.Clear();

            try
            {
                if(Cliente.Clientes.Count == 0)
                {
                    throw new Exception("Não há nenhum cliente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Lista de clientes:");
            foreach (var cliente in Cliente.Clientes)
            {
                Console.WriteLine($"ID: {cliente.Id} | Nome Completo: {cliente.Nome} {cliente.Sobrenome} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
            }
        }

        public static Cliente BuscarClientePorId()
        {
            Console.Clear();

            try
            {
                if (Cliente.Clientes.Count == 0)
                {
                    throw new ArgumentException("Não há nenhum cliente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            Console.WriteLine("Buscar cliente por Id:");

            int id = Verificacao.VerificarNumero(Console.ReadLine());

            Cliente cliente = Cliente.Clientes.Find(c => c.Id == id);

            while (cliente == null)
            {
                Console.Write("\nCliente não encontrado!\nDigite novamente o código do cliente: ");
                id = Verificacao.VerificarNumero(Console.ReadLine());
                cliente = Cliente.Clientes.Find(c => c.Id == id);
            }

            return cliente;

        }
    
        private void ExcluirCliente()
        {
            Console.Clear();

            try
            {
                if (Cliente.Clientes.Count == 0)
                {
                    throw new Exception("Não há nenhum cliente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Excluir cliente");

            Console.Write("ID do cliente: ");
            int id = Verificacao.VerificarNumero(Console.ReadLine());

            Cliente cliente = Cliente.Clientes.Find(c => c.Id == id);

            while (cliente == null)
            {
                Console.Write("\nCliente não encontrado!\nDigite novamente o código do cliente: ");
                id = Verificacao.VerificarNumero(Console.ReadLine());
                cliente = Cliente.Clientes.Find(c => c.Id == id);
            }

            Cliente.Clientes.Remove(cliente);
        }
    }
}
