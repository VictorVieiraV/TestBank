using Dominio;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class RelatorioTests
    {
        private Relatorio relatorio;
        private Conta conta;
        private List<TransacaoObj> listaTransacoes;
        private List<ContaObj> listaContas;

        [TestInitialize]
        public void Initialize()
        {
            listaContas = new List<ContaObj>()
        {
            new ContaObj { Id = 1, Saldo = 1000.0 },
            new ContaObj { Id = 2, Saldo = 2000.0 },
            new ContaObj { Id = 3, Saldo = 3000.0 }
        };

            conta = new Conta(listaContas);

            listaTransacoes = new List<TransacaoObj>()
        {
            new TransacaoObj { IdConta = 1, IdTransacao = 1, Valor = 100.0 },
            new TransacaoObj { IdConta = 1, IdTransacao = 2, Valor = 200.0 }
        };

            relatorio = new Relatorio(conta, listaTransacoes);
        }

        [TestMethod]
        public void ObterSaldo_ExistingAccount_ShouldReturnBalance()
        {
            // Arrange
            int numeroConta = 1;

            // Act
            string result = relatorio.ObterSaldo(numeroConta);

            // Assert
            Assert.AreEqual("Saldo atual da conta 1: R$ 1000", result);
        }

        [TestMethod]
        public void ObterSaldo_NonExistingAccount_ShouldReturnErrorMessage()
        {
            // Arrange
            int numeroConta = 5;

            // Act
            string result = relatorio.ObterSaldo(numeroConta);

            // Assert
            Assert.AreEqual("Conta não encontrada.", result);
        }

        [TestMethod]
        public void ConsultarExtrato_ExistingAccountWithTransactions_ShouldReturnTransactions()
        {
            // Arrange
            int numeroConta = 1;
            int idTransacao = 2;

            // Act
            string result = relatorio.ConsultarExtrato(numeroConta, idTransacao);

            // Assert
            Assert.AreEqual($"IdConta: {1}, Valor: {200.0}", result);
        }

        [TestMethod]
        public void ConsultarExtrato_ExistingAccountWithoutTransactions_ShouldReturnNoTransactionsMessage()
        {
            // Arrange
            int numeroConta = 2;

            // Act
            string result = relatorio.ConsultarExtrato(numeroConta, 0);

            // Assert
            Assert.AreEqual("Conta não possui transações.", result);
        }

        [TestMethod]
        public void ConsultarExtrato_NonExistingAccount_ShouldReturnErrorMessage()
        {
            // Arrange
            int numeroConta = 4;

            // Act
            string result = relatorio.ConsultarExtrato(numeroConta, 0);

            // Assert
            Assert.AreEqual("Conta não encontrada.", result);
        }

        [TestMethod]
        public void GerarRelatorioTransacoes_WithTransactions_ShouldReturnReport()
        {
            // Act
            string result = relatorio.GerarRelatorioTransacoes();

            // Assert
            Assert.AreEqual($"Conta: {1}    /    Saldo {100}", result);
        }

        [TestMethod]
        public void GerarRelatorioTransacoes_WithoutTransactions_ShouldReturnErrorMessage()
        {
            // Arrange
            listaTransacoes.Clear();

            // Act
            string result = relatorio.GerarRelatorioTransacoes();

            // Assert
            Assert.AreEqual("Não foi possível gerar o relatorio.", result);
        }
    }
}
