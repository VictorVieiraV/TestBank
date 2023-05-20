using Dominio;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class InvestimentoTests
    {
        private Investimento _investimento;
        private List<ContaObj> _listaContas;
        private List<InvestimentoObj> _listaInvestimento;


        [TestInitialize]
        public void Initialize()
        {
            _listaContas = new List<ContaObj>() {
                new ContaObj { Id = 1, Saldo = 1000.0 },
                new ContaObj { Id = 2, Saldo = 2000.0 }
            };
            _listaInvestimento = new List<InvestimentoObj>();
            _investimento = new Investimento(_listaInvestimento, new Conta(_listaContas));
        }

        [TestMethod]
        public void RealizarInvestimento_EntradaValida_SomaInvestimentoAtualizarSaldo()
        {
            // Arrange
            int idConta = 1;
            double valorInserido = 100.0;

            // Act
            string result = _investimento.RealizarInvestimento(idConta, valorInserido);

            // Assert
            ContaObj conta = _listaContas.FirstOrDefault(c => c.Id == idConta);
            Assert.AreEqual("Investimento realizado com sucesso. Novo saldo: 900", result);
            Assert.AreEqual(1, _investimento.BuscarInvestimentosPorConta(idConta).Count);
            Assert.AreEqual(900.0, conta.Saldo);
        }

        [TestMethod]
        public void RealizarInvestimento_EntradaInvalida_NaoAdicionaInvestimento()
        {
            // Arrange
            int idConta = 1;
            double valorInserido = -100.0;

            // Act
            string result = _investimento.RealizarInvestimento(idConta, valorInserido);

            // Assert
            ContaObj conta = _listaContas.FirstOrDefault(c => c.Id == idConta);
            Assert.AreEqual("Valor inválido.", result);
            Assert.AreEqual(0, _investimento.BuscarInvestimentosPorConta(idConta).Count);
            Assert.AreEqual(1000.0, conta.Saldo);
        }

        [TestMethod]
        public void ResgatarInvestimento_InvestimentoExistente_AtualizaSaldo()
        {
            // Arrange
            int numeroConta = 1;
            int idInvestimento = 1;
            var investimentoObj = new InvestimentoObj()
            {
                IdConta = numeroConta,
                IdInvestimento = idInvestimento,
                PorcentagemGanhos = 0.02,
                Valor = 100.0
            };
            _listaInvestimento.Add(investimentoObj);

            // Act
            string result = _investimento.ResgatarInvestimento(numeroConta, idInvestimento);

            // Assert
            ContaObj conta = _listaContas.FirstOrDefault(c => c.Id == numeroConta);
            Assert.AreEqual("Investimento resgatado com sucesso. Novo saldo bancario: 1102", result);
            Assert.AreEqual(1102.0, conta.Saldo);
        }

        [TestMethod]
        public void ResgatarInvestimento_InvestimentoNaoExiste_NaoAtualizaSaldo()
        {
            // Arrange
            int numeroConta = 1;
            int idInvestimento = 1;

            // Act
            string result = _investimento.ResgatarInvestimento(numeroConta, idInvestimento);

            // Assert
            ContaObj conta = _listaContas.FirstOrDefault(c => c.Id == numeroConta);
            Assert.AreEqual("Investimentos não encontrados.", result);
            Assert.AreEqual(1000.0, conta.Saldo);
        }

        [TestMethod]
        public void BuscarInvestimentosPorConta_InvestimentosExistentes_RetornaListaInvestimentos()
        {
            // Arrange
            int numeroConta = 1;
            var investimentoObj1 = new InvestimentoObj()
            {
                IdConta = numeroConta,
                IdInvestimento = 1,
                PorcentagemGanhos = 2.00,
                Valor = 100.0
            };
            var investimentoObj2 = new InvestimentoObj()
            {
                IdConta = numeroConta,
                IdInvestimento = 2,
                PorcentagemGanhos = 3.00,
                Valor = 200.0
            };
            _listaInvestimento.Add(investimentoObj1);
            _listaInvestimento.Add(investimentoObj2);

            // Act
            List<InvestimentoObj> result = _investimento.BuscarInvestimentosPorConta(numeroConta);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Any(i => i.IdInvestimento == 1));
            Assert.IsTrue(result.Any(i => i.IdInvestimento == 2));
            Assert.IsFalse(result.Any(i => i.IdInvestimento == 3));
        }
    }
}
