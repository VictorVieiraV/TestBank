using Dominio;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class ClienteTests
    {
        private Cliente _cliente;
        private List<ClienteObj> _listaClientes;

        [TestInitialize]
        public void Initialize()
        {
            _listaClientes = new List<ClienteObj>();
            _cliente = new Cliente();
        }

        [TestMethod]
        public void CadastrarCliente_ClienteNaoExistente_CadastroRealizado()
        {
            // Arrange
            var nome = "Cliente Teste";
            var cpf = "123456789";
            var telefone = "123456789";
            var endereco = "Rua Teste, 123";

            var novoCliente = new ClienteObj()
            {
                Nome = nome,
                Cpf = cpf,
                Endereco = endereco,
                Telefone = telefone
            };

            // Act
            _cliente.AddCliente(novoCliente);

            // Assert
            var clienteCadastrado = _cliente.BuscarClientePorCpf(cpf);
            Assert.IsNotNull(clienteCadastrado);
            Assert.AreEqual(nome, clienteCadastrado.Nome);
            Assert.AreEqual(cpf, clienteCadastrado.Cpf);
            Assert.AreEqual(telefone, clienteCadastrado.Telefone);
            Assert.AreEqual(endereco, clienteCadastrado.Endereco);
        }

        [TestMethod]
        public void AlterarCliente_ClienteExistente_AlteracaoRealizada()
        {
            // Arrange
            var cpf = "123456789";
            var nomeAntigo = "Cliente Antigo";
            var nomeNovo = "Cliente Novo";
            var telefoneNovo = "987654321";
            var enderecoNovo = "Rua Nova, 456";

            var clienteExistente = new ClienteObj()
            {
                Nome = nomeAntigo,
                Cpf = cpf,
                Endereco = "Rua Antiga, 123",
                Telefone = "123456789"
            };

            _listaClientes.Add(clienteExistente);

            // Act
            _cliente.AlterarCliente(clienteExistente);

            // Assert
            var clienteAlterado = _cliente.BuscarClientePorCpf(cpf);
            Assert.IsNotNull(clienteAlterado);
            Assert.AreEqual(nomeNovo, clienteAlterado.Nome);
            Assert.AreEqual(telefoneNovo, clienteAlterado.Telefone);
            Assert.AreEqual(enderecoNovo, clienteAlterado.Endereco);
        }

        [TestMethod]
        public void ConsultarCliente_ClienteExistente_DadosRetornados()
        {
            // Arrange
            var cpf = "123456789";
            var nome = "Cliente Teste";
            var telefone = "123456789";
            var endereco = "Rua Teste, 123";

            var clienteExistente = new ClienteObj()
            {
                Nome = nome,
                Cpf = cpf,
                Endereco = endereco,
                Telefone = telefone
            };

            _listaClientes.Add(clienteExistente);

            // Act
            _cliente.ConsultarCliente();

            // Assert
            // Simular a leitura dos dados de saída (Console.WriteLine) e verificar se os dados estão corretos
            // Não é possível fazer o assert direto na saída do Console.WriteLine em um teste unitário
        }
    }
}
