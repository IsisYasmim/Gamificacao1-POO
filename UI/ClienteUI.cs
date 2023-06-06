using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ClienteUI
    {
        // Adicionar um novo cliente
        public static void AdicionarCliente(int id, string nome, string sobrenome, string endereco, string telefone, List<Cliente> clientes)
        {
            Cliente cliente = new Cliente(id, nome, sobrenome, endereco, telefone);
            clientes.Add(cliente);
        }

        // Alterar dados de um cliente com base no ID
        public static void AlterarCliente(int id, string nome, string sobrenome, string endereco, string telefone, List<Cliente> clientes)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                cliente.Nome = nome;
                cliente.Sobrenome = sobrenome;
                cliente.Endereco = endereco;
                cliente.Telefone = telefone;
            }
        }

        // Remover um cliente com base no ID
        public static void RemoverCliente(int id, List<Cliente> clientes)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }

        // Listar todas as vendas de um cliente
        public static void ListarVendas(int id, List<Cliente> clientes)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                Console.WriteLine($"Vendas do cliente {cliente.Nome} {cliente.Sobrenome}:");
                foreach (Venda venda in cliente.Vendas)
                {
                    Console.WriteLine($"ID da venda: {venda.Id}");
                }
            }
        }

        public static void ListarClientes(List<Cliente> clientes)
        {
            Console.WriteLine("Clientes cadastrados:");
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"ID : {cliente.Id} | Nome: {cliente.Nome} {cliente.Sobrenome} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
            }
        }

        public static Cliente BuscarClientePorId(int id, List<Cliente> clientes)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);
            return cliente;
        }

        public static void AdicionarVendas(int idCliente, List<Venda> vendas, List<Cliente> clientes)
        {
            Cliente cliente = clientes.Find(c => c.Id == idCliente);
            if (cliente != null)
            {
                cliente.Vendas.AddRange(vendas);
            }
        }

        public static void MenuCliente(List<Cliente> clientes, List<Venda> vendas)
        {
            int opcao;
            do
            {

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar cliente");
                Console.WriteLine("2 - Remover cliente");
                Console.WriteLine("3 - Alterar cliente");
                Console.WriteLine("4 - Ver clientes adicionados");
                Console.WriteLine("5 - Ver vendas realizadas para cada cliente");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        int id;
                        string nome, sobrenome, endereco, telefone;
                        Console.WriteLine("Escreva o ID do cliente:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o nome do cliente:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Escreva o sobrenome do cliente:");
                        sobrenome = Console.ReadLine();
                        Console.WriteLine("Escreva o endereço do cliente:");
                        endereco = Console.ReadLine();
                        Console.WriteLine("Escreva o telefone do cliente:");
                        telefone = Console.ReadLine();
                        AdicionarCliente(id, nome, sobrenome, endereco, telefone, clientes);

                        break;

                    case 2:

                        Console.WriteLine("Escreva o id do cliente para remover:");
                        id = int.Parse(Console.ReadLine());
                        RemoverCliente(id, clientes);

                        break;

                    case 3:
                        Console.WriteLine("Escreva o ID do cliente a ser alterado:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva o nome do cliente novo:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Escreva o sobrenome do cliente novo:");
                        sobrenome = Console.ReadLine();
                        Console.WriteLine("Escreva o endereço do cliente novo:");
                        endereco = Console.ReadLine();
                        Console.WriteLine("Escreva o telefone do cliente novo:");
                        telefone = Console.ReadLine();
                        AlterarCliente(id, nome, sobrenome, endereco, telefone, clientes);

                        break;

                    case 4:
                        ListarClientes(clientes);
                        break;

                    case 5:
                        Console.WriteLine("Escreva o ID do cliente:");
                        id = int.Parse(Console.ReadLine());
                        ListarVendas(id, clientes);
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
