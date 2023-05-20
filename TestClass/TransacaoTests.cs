using Dominio;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class TransacaoTests
    {
        private Transacao transacao;
        private Conta conta;

        [TestInitialize]
        public void TestInitialize()
        {
            List<ContaObj> listaContas = new List<ContaObj>()
        {
            new ContaObj { Id = 1, Saldo = 100.0 },
            new ContaObj { Id = 2, Saldo = 200.0 }
        };

            conta = new Conta(listaContas);
            transacao = new Transacao(conta);
        }

        [TestMethod]
        public void EfetuarDeposito_SeExisteConta_RealizaDepositoRetornaMensagemSucesso()
        {
            // Arrange
            int idConta = 1;
            double valorDepositado = 50.0;

            // Act
            string result = transacao.EfetuarDeposito(idConta, valorDepositado);

            // Assert
            Assert.AreEqual("Depósito realizado com sucesso. Novo saldo da conta: 150", result);
        }

        [TestMethod]
        public void EfetuarDeposito_SeNaoExisteConta_RetornaMensagemErro()
        {
            // Arrange
            int idConta = 3;
            double valorDepositado = 50.0;

            // Act
            string result = transacao.EfetuarDeposito(idConta, valorDepositado);

            // Assert
            Assert.AreEqual("Conta não encontrada.", result);
        }

        [TestMethod]
        public void EfetuarSaque_SeContaExisteESaldoSuficiente_RealizaSaqueERetornaMensagemSucesso()
        {
            // Arrange
            int idConta = 1;
            double valorSacado = 50.0;

            // Act
            string result = transacao.EfetuarSaque(idConta, valorSacado);

            // Assert
            Assert.AreEqual("Saque realizado com sucesso. Novo saldo da conta: 50", result);
        }

        [TestMethod]
        public void EfetuarSaque_SeExisteContaESaldoInsuficiente_RetornaMensagemErro()
        {
            // Arrange
            int idConta = 1;
            double valorSacado = 200.0;

            // Act
            string result = transacao.EfetuarSaque(idConta, valorSacado);

            // Assert
            Assert.AreEqual("Não foi possível realizar o saque.", result);
        }

        [TestMethod]
        public void EfetuarSaque_NaoExisteConta_RetornaMensagemErro()
        {
            // Arrange
            int idConta = 3;
            double valorSacado = 50.0;

            // Act
            string result = transacao.EfetuarSaque(idConta, valorSacado);

            // Assert
            Assert.AreEqual("Conta não encontrada.", result);
        }

        [TestMethod]
        public void EfetuarTransferencia_ExisteContaOrigemEContaDestinoESaldoSuficiente_RealizaTransferenciaERetornaMensagemSucesso()
        {
            // Arrange
            int idContaOrigem = 1;
            int idContaDestino = 2;
            double valor = 50.0;

            // Act
            List<string> result = transacao.EfetuarTransferencia(idContaOrigem, idContaDestino, valor);

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Transferência realizada com sucesso.", result[0]);
            Assert.AreEqual("Novo saldo da conta de origem: 50", result[1]);
            Assert.AreEqual("Novo saldo da conta de destino: 250", result[2]);
        }

        [TestMethod]
        public void EfetuarTransferencia_ExisteContaOrigemEContaDestinoESaldoInsuficiente_RetornaMensagemErro()
        {
            // Arrange
            int idContaOrigem = 1;
            int idContaDestino = 2;
            double valor = 200.0;

            // Act
            List<string> result = transacao.EfetuarTransferencia(idContaOrigem, idContaDestino, valor);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Saldo insuficiente na conta de origem.", result[0]);
        }

        [TestMethod]
        public void EfetuarTransferencia_NaoExisteContaOrigem_RetornaMensagemErro()
        {
            // Arrange
            int idContaOrigem = 3;
            int idContaDestino = 2;
            double valor = 50.0;

            // Act
            List<string> result = transacao.EfetuarTransferencia(idContaOrigem, idContaDestino, valor);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Conta de origem não encontrada.", result[0]);
        }

        [TestMethod]
        public void EfetuarTransferencia_ExisteContaOrigemNaoExisteContaDestino_RetornaMensagemErro()
        {
            // Arrange
            int idContaOrigem = 1;
            int idContaDestino = 3;
            double valor = 50.0;

            // Act
            List<string> result = transacao.EfetuarTransferencia(idContaOrigem, idContaDestino, valor);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Conta de destino não encontrada.", result[0]);
        }
    }
}
