using Dominio;

namespace TestBank.Class
{
    public class Cliente
    {
        List<ClienteObj> listaClientes = new List<ClienteObj>();

        public void CadastrarCliente()
        {
            Console.WriteLine("Digite o nome do cliente:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF do cliente:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o telefone do cliente:");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço do cliente:");
            string endereco = Console.ReadLine();

            ClienteObj novoCliente = new ClienteObj()
            {
                Nome = nome,
                Cpf = cpf,
                Endereco = endereco,
                Telefone = telefone
            };
            AddCliente(novoCliente);

            Console.WriteLine($"Cliente {nome} cadastrado com sucesso!");
        }

        public void AlterarCliente(ClienteObj cli)
        {
            ClienteObj cliente = BuscarClientePorCpf(cli.Cpf);

            if (cliente.Cpf != null)
            {
                cliente.Nome = cli.Nome;
                cliente.Telefone = cli.Telefone;
                cliente.Endereco = cli.Endereco;
            }
        }

        public void ConsultarCliente()
        {
            Console.WriteLine("Digite o CPF do cliente que deseja consultar:");
            string cpf = Console.ReadLine();

            ClienteObj cliente = BuscarClientePorCpf(cpf);

            if (cliente.Cpf != null)
            {
                Console.WriteLine($"Dados Cliente");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.Cpf}");
            }
            else
            {
                Console.WriteLine($"Cliente com CPF {cpf} não encontrado.");
            }
        }

        public ClienteObj BuscarClientePorCpf(string cpf)
        {
            var cliente = listaClientes.Where(x => x.Cpf == cpf).FirstOrDefault();

            if (cliente != null)
            {
                return cliente;
            }
            return new ClienteObj();
        }

        public void AddCliente(ClienteObj clienteObj)
        {
            listaClientes.Add(clienteObj);
        }
    }
}