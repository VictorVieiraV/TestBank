using Dominio;
using System.Reflection;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class FaturaTests
    {
        private Fatura _fatura;
        private Conta _conta;
        private List<FaturaObj> _listaFaturas;

        [TestInitialize]
        public void Initialize()
        {
            _conta = new Conta(new List<ContaObj>());
            _listaFaturas = new List<FaturaObj>();
            _fatura = new Fatura(_listaFaturas, _conta);
        }

        [TestMethod]
        public void ConsultarFaturasEmAberto_RetornaFaturasEmAberto()
        {
            // Arrange
            int idConta = 1;
            var fatura1 = new FaturaObj()
            {
                IdFatura = 1,
                IdConta = idConta,
                StatusFatura = Enums.StatusFatura.Aberta,
                Valor = 100.00
            };
            var fatura2 = new FaturaObj()
            {
                IdFatura = 2,
                IdConta = idConta,
                StatusFatura = Enums.StatusFatura.Aberta,
                Valor = 200.00
            };
            var fatura3 = new FaturaObj()
            {
                IdFatura = 3,
                IdConta = idConta,
                StatusFatura = Enums.StatusFatura.Vencida,
                Valor = 150.00
            };
            _listaFaturas.Add(fatura1);
            _listaFaturas.Add(fatura2);
            _listaFaturas.Add(fatura3);

            // Act
            var result = _fatura.ConsultarFaturasEmAberto(idConta);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(fatura1));
            Assert.IsTrue(result.Contains(fatura2));
            Assert.IsFalse(result.Contains(fatura3));
        }

        [TestMethod]
        public void ConsultarFaturasEmAberto_NenhumaFaturaEmDia_RetornaListaVazia()
        {
            // Arrange
            int idConta = 1;
            var fatura1 = new FaturaObj()
            {
                IdFatura = 1,
                IdConta = idConta,
                StatusFatura = Enums.StatusFatura.Vencida,
                Valor = 100.00
            };
            var fatura2 = new FaturaObj()
            {
                IdFatura = 2,
                IdConta = idConta,
                StatusFatura = Enums.StatusFatura.Vencida,
                Valor = 200.00
            };
            _listaFaturas.Add(fatura1);
            _listaFaturas.Add(fatura2);

            // Act
            var result = _fatura.ConsultarFaturasEmAberto(idConta);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void PagarFatura_FaturaEmDia_PagaFaturaComSucesso()
        {
            // Arrange
            int idFatura = 1;
            var fatura = new FaturaObj()
            {
                IdFatura = idFatura,
                IdConta = 1,
                StatusFatura = Enums.StatusFatura.Aberta,
                Valor = 100.00
            };
            _listaFaturas.Add(fatura);

            var conta = new ContaObj()
            {
                Id = 1,
                CpfCliente = "123456789",
                Saldo = 200.00,
                TipoConta = Enums.TipoConta.Poupanca
            };
            _conta.AddConta(conta);

            // Act
            string result = _fatura.PagarFatura(idFatura);

            // Assert
            Assert.AreEqual("Fatura paga com sucesso.", result);
            Assert.AreEqual(Enums.StatusFatura.Paga, fatura.StatusFatura);
            Assert.AreEqual(100.00, conta.Saldo);
        }

        [TestMethod]
        public void PagarFatura_FaturaEmDia_SaldoInsuficiente()
        {
            // Arrange
            int idFatura = 1;
            var fatura = new FaturaObj()
            {
                IdFatura = idFatura,
                IdConta = 1,
                StatusFatura = Enums.StatusFatura.Aberta,
                Valor = 200.00
            };
            _listaFaturas.Add(fatura);
            var conta = new ContaObj()
            {
                Id = 1,
                CpfCliente = "123456789",
                Saldo = 150.00,
                TipoConta = Enums.TipoConta.Poupanca
            };
            _conta.AddConta(conta);

            // Act
            string result = _fatura.PagarFatura(idFatura);

            // Assert
            Assert.AreEqual("Conta não possui saldo suficiente para pagar fatura.", result);
            Assert.AreEqual(Enums.StatusFatura.Aberta, fatura.StatusFatura);
            Assert.AreEqual(150.00, conta.Saldo);
        }

        [TestMethod]
        public void PagarFatura_FaturaEmDia_ContaNaoEncontrada()
        {
            // Arrange
            int idFatura = 1;
            var fatura = new FaturaObj()
            {
                IdFatura = idFatura,
                IdConta = 1,
                StatusFatura = Enums.StatusFatura.Aberta,
                Valor = 100.00
            };
            _listaFaturas.Add(fatura);

            // Act
            string result = _fatura.PagarFatura(idFatura);

            // Assert
            Assert.AreEqual("Conta não encontrada.", result);
            Assert.AreEqual(Enums.StatusFatura.Aberta, fatura.StatusFatura);
        }

        [TestMethod]
        public void PagarFatura_FaturaNaoEncontrada()
        {
            // Arrange
            int idFatura = 1;

            // Act
            string result = _fatura.PagarFatura(idFatura);

            // Assert
            Assert.AreEqual("Fatura não encontrada.", result);
        }
    }
}
