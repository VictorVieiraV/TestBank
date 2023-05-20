using Dominio;
using TestBank.Class;

namespace TestClass
{
    [TestClass]
    public class TaxaTests
    {
        private Taxa taxa;
        private List<TaxaObj> listaTaxas;

        [TestInitialize]
        public void TestInitialize()
        {
            listaTaxas = new List<TaxaObj>()
        {
            new TaxaObj { IdTaxa = 1, Descricao = "Taxa 1", Valor = 10.0 },
            new TaxaObj { IdTaxa = 2, Descricao = "Taxa 2", Valor = 20.0 }
        };

            taxa = new Taxa(listaTaxas);
        }

        [TestMethod]
        public void AdicionarTaxa_ValidParameters_ShouldAddTaxaAndReturnSuccessMessage()
        {
            // Arrange
            string descricao = "Nova Taxa";
            double valor = 30.0;

            // Act
            string result = taxa.AdicionarTaxa(descricao, valor);

            // Assert
            Assert.AreEqual("Taxa adicionada com sucesso!", result);
            Assert.AreEqual(3, listaTaxas.Count);
            Assert.AreEqual(descricao, listaTaxas[2].Descricao);
            Assert.AreEqual(valor, listaTaxas[2].Valor);
        }

        [TestMethod]
        public void RemoverTaxa_ExistingTaxaId_ShouldRemoveTaxaAndReturnSuccessMessage()
        {
            // Arrange
            int idTaxa = 1;

            // Act
            string result = taxa.RemoverTaxa(idTaxa);

            // Assert
            Assert.AreEqual("Taxa removida com sucesso!", result);
            Assert.AreEqual(1, listaTaxas.Count);
            Assert.AreEqual("Taxa 2", listaTaxas[0].Descricao);
            Assert.AreEqual(20.0, listaTaxas[0].Valor);
        }

        [TestMethod]
        public void RemoverTaxa_NonExistingTaxaId_ShouldReturnErrorMessage()
        {
            // Arrange
            int idTaxa = 3;

            // Act
            string result = taxa.RemoverTaxa(idTaxa);

            // Assert
            Assert.AreEqual("Taxa não encontrada.", result);
            Assert.AreEqual(2, listaTaxas.Count);
        }

        [TestMethod]
        public void BuscarTaxaPorId_ExistingTaxaId_ShouldReturnTaxaObject()
        {
            // Arrange
            int idTaxa = 1;

            // Act
            TaxaObj result = taxa.BuscarTaxaPorId(idTaxa);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(idTaxa, result.IdTaxa);
            Assert.AreEqual("Taxa 1", result.Descricao);
            Assert.AreEqual(10.0, result.Valor);
        }

        [TestMethod]
        public void BuscarTaxaPorId_NonExistingTaxaId_ShouldReturnNull()
        {
            // Arrange
            int idTaxa = 3;

            // Act
            TaxaObj result = taxa.BuscarTaxaPorId(idTaxa);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConsultarTodasTaxas_WithTaxas_ShouldReturnListOfTaxaDescriptions()
        {
            // Act
            List<string> result = taxa.ConsultarTodasTaxas();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Id:1   /   Descricao: Taxa 1   /   Valor: 10", result[0]);
            Assert.AreEqual("Id:2   /   Descricao: Taxa 2   /   Valor: 20", result[1]);
        }

        [TestMethod]
        public void ConsultarTodasTaxas_WithoutTaxas_ShouldReturnEmptyList()
        {
            // Arrange
            listaTaxas.Clear();

            // Act
            List<string> result = taxa.ConsultarTodasTaxas();

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
