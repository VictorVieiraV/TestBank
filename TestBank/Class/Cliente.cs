using Dominio;

namespace TestBank.Class
{
    public class Cliente
    {
        private List<ClienteObj> _listaClientes;

        public Cliente(List<ClienteObj> listaClientes)
        {
            _listaClientes = listaClientes;
        }

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
            foreach (var item in _listaClientes)
            {
                if (item.Cpf == cli.Cpf)
                {
                    item.Nome = cli.Nome;
                    item.Telefone = cli.Telefone;
                    item.Endereco = cli.Endereco;
                }
            }
        }

        public ClienteObj BuscarClientePorCpf(string cpf)
        {
            var cliente = _listaClientes.Where(x => x.Cpf == cpf).FirstOrDefault();

            if (cliente != null)
            {
                return cliente;
            }
            return new ClienteObj();
        }

        public void AddCliente(ClienteObj clienteObj)
        {
            _listaClientes.Add(clienteObj);
        }
    }
}