using Dominio;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class ContaTests
    {
        private Conta _conta;
        private List<ContaObj> _listaContas;

        [TestInitialize]
        public void Initialize()
        {
            _listaContas = new List<ContaObj>();
            _conta = new Conta(_listaContas);
        }

        [TestMethod]
        public void AddConta_NovaConta_ContaAdicionada()
        {
            // Arrange
            var conta = new ContaObj()
            {
                Id = 1,
                CpfCliente = "123456789",
                Saldo = 0.00,
                TipoConta = Enums.TipoConta.Poupanca
            };

            // Act
            _conta.AddConta(conta);

            // Assert
            Assert.AreEqual(1, _listaContas.Count);
            Assert.AreEqual(conta, _listaContas[0]);
        }

        [TestMethod]
        public void AbrirConta_TipoContaCorrente_ContaCorrenteCriada()
        {
            // Arrange
            var cpf = "123456789";
            var tipoConta = 1;
            var conta = new ContaObj()
            {
                CpfCliente = cpf,
                Saldo = 0.00,
                TipoConta = Enums.TipoConta.Poupanca
            };
            // Act
            _conta.AbrirConta(conta);

            // Assert
            Assert.AreEqual(1, _listaContas.Count);
            Assert.AreEqual(cpf, _listaContas[0].CpfCliente);
            Assert.AreEqual(Enums.TipoConta.Poupanca, _listaContas[0].TipoConta);
        }

        [TestMethod]
        public void FecharConta_ContaExistenteComSaldoPositivo_ContaFechada()
        {
            // Arrange
            var conta = new ContaObj()
            {
                Id = 1,
                CpfCliente = "123456789",
                Saldo = 100.00,
                TipoConta = Enums.TipoConta.Poupanca
            };

            _listaContas.Add(conta);

            // Act
            _conta.FecharConta(conta.Id);

            // Assert
            Assert.AreEqual(0, _listaContas.Count);
        }

        [TestMethod]
        public void BuscarContasPorCpf_CpfExistente_ContasRetornadas()
        {
            // Arrange
            var cpf = "123456789";
            var conta1 = new ContaObj()
            {
                Id = 1,
                CpfCliente = cpf,
                Saldo = 0.00,
                TipoConta = Enums.TipoConta.Poupanca
            };
            var conta2 = new ContaObj()
            {
                Id = 2,
                CpfCliente = cpf,
                Saldo = 0.00,
                TipoConta = Enums.TipoConta.Corrente
            };

            _listaContas.Add(conta1);
            _listaContas.Add(conta2);

            // Act
            var contas = _conta.BuscarContasPorCpf(cpf);

            // Assert
            Assert.AreEqual(2, contas.Count);
            CollectionAssert.Contains(contas, conta1);
            CollectionAssert.Contains(contas, conta2);
        }

        [TestMethod]
        public void BuscarContaPorId_IdExistente_ContaRetornada()
        {
            // Arrange
            var id = 1;
            var conta = new ContaObj()
            {
                Id = id,
                CpfCliente = "123456789",
                Saldo = 0.00,
                TipoConta = Enums.TipoConta.Poupanca
            };

            _listaContas.Add(conta);

            // Act
            var contaEncontrada = _conta.BuscarContaPorId(id);

            // Assert
            Assert.AreEqual(conta, contaEncontrada);
        }

        [TestMethod]
        public void EfetuarDebito_SaldoSuficiente_DebitoEfetuado()
        {
            // Arrange
            var valor = 50.00;
            var idConta = 1;
            var conta = new ContaObj()
            {
                Id = idConta,
                CpfCliente = "123456789",
                Saldo = 100.00,
                TipoConta = Enums.TipoConta.Poupanca
            };

            _listaContas.Add(conta);

            // Act
            var resultado = _conta.EfetuarDebito(valor, idConta);

            // Assert
            Assert.IsTrue(resultado);
            Assert.AreEqual(50.00, conta.Saldo);
        }

        [TestMethod]
        public void EfetuarDebito_SaldoInsuficiente_DebitoNaoEfetuado()
        {
            // Arrange
            var valor = 150.00;
            var idConta = 1;
            var conta = new ContaObj()
            {
                Id = idConta,
                CpfCliente = "123456789",
                Saldo = 100.00,
                TipoConta = Enums.TipoConta.Poupanca
            };

            _listaContas.Add(conta);

            // Act
            var resultado = _conta.EfetuarDebito(valor, idConta);

            // Assert
            Assert.IsFalse(resultado);
            Assert.AreEqual(100.00, conta.Saldo);
        }

        [TestMethod]
        public void EfetuarDeposito_DepositoEfetuado()
        {
            // Arrange
            var valor = 50.00;
            var idConta = 1;
            var conta = new ContaObj()
            {
                Id = idConta,
                CpfCliente = "123456789",
                Saldo = 100.00,
                TipoConta = Enums.TipoConta.Poupanca
            };

            _listaContas.Add(conta);

            // Act
            var resultado = _conta.EfetuarDeposito(valor, idConta);

            // Assert
            Assert.IsTrue(resultado);
            Assert.AreEqual(150.00, conta.Saldo);
        }

        [TestMethod]
        public void RealizarTransferencia_TransferenciaRealizada()
        {
            // Arrange
            var valor = 50.00;
            var contaOrigem = new ContaObj()
            {
                Id = 1,
                CpfCliente = "123456789",
                Saldo = 100.00,
                TipoConta = Enums.TipoConta.Poupanca
            };
            var contaDestino = new ContaObj()
            {
                Id = 2,
                CpfCliente = "987654321",
                Saldo = 0.00,
                TipoConta = Enums.TipoConta.Corrente
            };

            _listaContas.Add(contaOrigem);
            _listaContas.Add(contaDestino);

            double saldoOrigem, saldoDestino;

            // Act
            var resultado = _conta.RealizarTransferencia(contaOrigem, contaDestino, valor, out saldoOrigem, out saldoDestino);

            // Assert
            Assert.IsTrue(resultado);
            Assert.AreEqual(50.00, saldoOrigem);
            Assert.AreEqual(50.00, saldoDestino);
        }

        [TestMethod]
        public void RealizarTransferencia_SaldoInsuficiente_TransferenciaNaoRealizada()
        {
            // Arrange
            var valor = 150.00;
            var contaOrigem = new ContaObj()
            {
                Id = 1,
                CpfCliente = "123456789",
                Saldo = 100.00,
                TipoConta = Enums.TipoConta.Poupanca
            };
            var contaDestino = new ContaObj()
            {
                Id = 2,
                CpfCliente = "987654321",
                Saldo = 0.00,
                TipoConta = Enums.TipoConta.Corrente
            };

            _listaContas.Add(contaOrigem);
            _listaContas.Add(contaDestino);

            double saldoOrigem, saldoDestino;

            // Act
            var resultado = _conta.RealizarTransferencia(contaOrigem, contaDestino, valor, out saldoOrigem, out saldoDestino);

            // Assert
            Assert.IsFalse(resultado);
            Assert.AreEqual(0.00, saldoOrigem);
            Assert.AreEqual(0.00, saldoDestino);
        }
    }
}
