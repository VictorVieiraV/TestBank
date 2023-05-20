using Dominio;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class BoletoTests
    {
        private Boleto _boleto;
        private Cliente _cliente;
        private Conta _conta;
        private List<BoletoObj> _listaBoletos;

        [TestInitialize]
        public void Initialize()
        {
            _cliente = new Cliente();
            _conta = new Conta();
            _listaBoletos = new List<BoletoObj>();
            _boleto = new Boleto(_cliente, _conta, _listaBoletos);
        }

        [TestMethod]
        public void BuscarBoletoPorId_BoletoExistente_RetornaBoleto()
        {
            // Arrange
            var boletoObj = new BoletoObj { IdBoleto = 1 };
            _listaBoletos.Add(boletoObj);

            // Act
            var result = _boleto.BuscarBoletoPorId(1);

            // Assert
            Assert.AreEqual(boletoObj, result);
        }

        [TestMethod]
        public void BuscarBoletoPorId_BoletoNaoExistente_RetornaNovoBoletoObj()
        {
            // Act
            var result = _boleto.BuscarBoletoPorId(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BoletoObj));
        }

        [TestMethod]
        public void PagarBoleto_BoletoExistente_ContaComSaldo_Sucesso()
        {
            // Arrange
            var boletoObj = new BoletoObj { IdBoleto = 1, IdConta = 1, CpfCliente = "123456789" };
            var contaObj = new ContaObj { Id = 1, Saldo = 100.0 };
            var clienteObj = new ClienteObj { Cpf = "123456789", Nome = "Cliente Teste" };
            _listaBoletos.Add(boletoObj);
            _conta.AddConta(contaObj);
            _cliente.AddCliente(clienteObj);

            // Act
            var result = _boleto.PagarBoleto(1, 50.0);

            // Assert
            Assert.AreEqual("Boleto pago com sucesso para o cliente Cliente Teste.", result);
            Assert.AreEqual(50.0, contaObj.Saldo);
        }

        [TestMethod]
        public void PagarBoleto_BoletoExistente_ContaSemSaldo_SaldoInsuficiente()
        {
            // Arrange
            var boletoObj = new BoletoObj { IdBoleto = 1, IdConta = 1, CpfCliente = "123456789" };
            var contaObj = new ContaObj { Id = 1, Saldo = 50.0 };
            var clienteObj = new ClienteObj { Cpf = "123456789", Nome = "Cliente Teste" };
            _listaBoletos.Add(boletoObj);
            _conta.AddConta(contaObj);
            _cliente.AddCliente(clienteObj);

            // Act
            var result = _boleto.PagarBoleto(1, 100.0);

            // Assert
            Assert.AreEqual("Não há saldo suficiente na conta para realizar o pagamento.", result);
            Assert.AreEqual(50.0, contaObj.Saldo);
        }

        [TestMethod]
        public void PagarBoleto_BoletoNaoExistente_BoletoNaoEncontrado()
        {
            // Act
            var result = _boleto.PagarBoleto(1, 50.0);

            // Assert
            Assert.AreEqual("Boleto não encontrado.", result);
        }

        [TestMethod]
        public void GerarBoleto_ClienteExistente_ContaExistente_BoletoGerado()
        {
            // Arrange
            var clienteObj = new ClienteObj { Cpf = "123456789", Nome = "Cliente Teste" };
            var contaObj = new ContaObj { Id = 1 };
            _cliente.AddCliente(clienteObj);
            _conta.AddConta(contaObj);

            // Act
            var result = _boleto.GerarBoleto("123456789", 1, 100.0);

            // Assert
            Assert.AreEqual("Boleto gerado com sucesso para o cliente Cliente Teste.", result);
            Assert.AreEqual(1, _listaBoletos.Count);
            Assert.AreEqual("123456789", _listaBoletos[0].CpfCliente);
            Assert.AreEqual(DateTime.Now.Date, _listaBoletos[0].DataVencimento.Date);
            Assert.AreEqual(1, _listaBoletos[0].IdConta);
            Assert.AreEqual(100.0, _listaBoletos[0].Valor);
        }

        [TestMethod]
        public void GerarBoleto_ClienteNaoExistente_ClienteNaoEncontrado()
        {
            // Act
            var result = _boleto.GerarBoleto("123456789", 1, 100.0);

            // Assert
            Assert.AreEqual("Cliente não encontrado.", result);
            Assert.AreEqual(0, _listaBoletos.Count);
        }

        [TestMethod]
        public void GerarBoleto_ContaNaoExistente_ContaNaoEncontrada()
        {
            // Arrange
            var clienteObj = new ClienteObj { Cpf = "123456789", Nome = "Cliente Teste" };
            _cliente.AddCliente(clienteObj);

            // Act
            var result = _boleto.GerarBoleto("123456789", 1, 100.0);

            // Assert
            Assert.AreEqual("Conta não encontrada para o cpf 123456789.", result);
            Assert.AreEqual(0, _listaBoletos.Count);
        }
    }
}